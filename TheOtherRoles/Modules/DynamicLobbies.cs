using System;
using HarmonyLib;
using Hazel;
using InnerNet;
using TheOtherRoles.Utilities;

namespace TheOtherRoles.Modules {
    [HarmonyPatch]
    public static class DynamicLobbies {
        public static int LobbyLimit = 15;
        [HarmonyPatch(typeof(ChatController), nameof(ChatController.SendChat))]
        private static class SendChatPatch {
            static bool Prefix(ChatController __instance) {
                string text = __instance.TextArea.text;
                bool handled = false;
                if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started) {
                    if (text.ToLower().StartsWith("/size ")) { // Unfortunately server holds this - need to do more trickery
                            if (AmongUsClient.Instance.AmHost && AmongUsClient.Instance.CanBan()) { // checking both just cause
                                handled = true;
                                if (!Int32.TryParse(text.Substring(6), out LobbyLimit)) {
                                    __instance.AddChat(PlayerControl.LocalPlayer, "不正确的房间大小\n请使用: /size {amount}");
                                } else {
                                    LobbyLimit = Math.Clamp(LobbyLimit, 4, 15);
                                    if (LobbyLimit != PlayerControl.GameOptions.MaxPlayers) {
                                        PlayerControl.GameOptions.MaxPlayers = LobbyLimit;
                                        FastDestroyableSingleton<GameStartManager>.Instance.LastPlayerCount = LobbyLimit;
                                        PlayerControl.LocalPlayer.RpcSyncSettings(PlayerControl.GameOptions);
                                        __instance.AddChat(PlayerControl.LocalPlayer, $"房间大小改变成了{LobbyLimit}位玩家");
                                    } else {
                                        __instance.AddChat(PlayerControl.LocalPlayer, $"房间大小已经是{LobbyLimit}了");
                                    }
                                }
                            }
                        }
                }
                if (handled) {
                    __instance.TextArea.Clear();
                    __instance.quickChatMenu.ResetGlyphs();
                }
                return !handled;
            }
        }
        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.HostGame))]
        public static class InnerNetClientHostPatch {
            public static void Prefix(InnerNet.InnerNetClient __instance, [HarmonyArgument(0)] GameOptionsData settings) {
                DynamicLobbies.LobbyLimit = settings.MaxPlayers;
                settings.MaxPlayers = 15; // Force 15 Player Lobby on Server
                SaveManager.ChatModeType = InnerNet.QuickChatModes.FreeChatOrQuickChat;
            }
            public static void Postfix(InnerNet.InnerNetClient __instance, [HarmonyArgument(0)] GameOptionsData settings) {
                settings.MaxPlayers = DynamicLobbies.LobbyLimit;
            }
        }
        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.JoinGame))]
        public static class InnerNetClientJoinPatch {
            public static void Prefix(InnerNet.InnerNetClient __instance) {
                SaveManager.ChatModeType = InnerNet.QuickChatModes.FreeChatOrQuickChat;
            }
        }
        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
        public static class AmongUsClientOnPlayerJoined {
            public static bool Prefix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData client) {
                if (LobbyLimit < __instance.allClients.Count) { // TODO: Fix this canceling start
                    DisconnectPlayer(__instance, client.Id);
                    return false;
                }
                return true;
            }

            private static void DisconnectPlayer(InnerNetClient _this, int clientId) {
			if (!_this.AmHost) {
				return;
			}
			MessageWriter messageWriter = MessageWriter.Get(SendOption.Reliable);
			messageWriter.StartMessage(4);
			messageWriter.Write(_this.GameId);
			messageWriter.WritePacked(clientId);
			messageWriter.Write((byte)DisconnectReasons.GameFull);
			messageWriter.EndMessage();
			_this.SendOrDisconnect(messageWriter);
			messageWriter.Recycle();
            }
        }
    }
}
