using System.Linq;
using System;
using System.Collections.Generic;
using static TheOtherRoles.TheOtherRoles;
using UnityEngine;

namespace TheOtherRoles
{
    class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;
        public bool isModifier;

        RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false, bool isModifier = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
            this.isModifier = isModifier;
        }

        public static RoleInfo jester = new RoleInfo("小丑", Jester.color, "想办法被投出去", "被投出去", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("市长", Mayor.color, "你的一票记作两票", "你的一票记作两票", RoleId.Mayor);
	public static RoleInfo portalmaker = new RoleInfo("传送师", Portalmaker.color, "你可以制造传送门", "你可以制造传送门", RoleId.Portalmaker);
        public static RoleInfo engineer = new RoleInfo("工程师",  Engineer.color, "维修飞船上的重要设施", "你可以维修被破坏的重要设施", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("警长", Sheriff.color, "干掉<color=#FF1919FF>内鬼</color>", "干掉内鬼", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("副官", Sheriff.color, "给<color=#FF1919FF>内鬼</color>戴上手铐", "给内鬼戴上手铐", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("执灯人", Lighter.color, "你的光芒永不熄灭", "你的光芒永不熄灭", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("教父", Godfather.color, "杀死所有船员", "杀死所有船员", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("小弟", Mafioso.color, "作为<color=#FF1919FF>黑手党</color>的成员杀死所有船员", "杀死所有船员", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("清洁工", Janitor.color, "作为<color=#FF1919FF>黑手党</color>的成员，清理尸体", "清理尸体", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("化形者", Morphling.color, "变换外貌来摆脱嫌疑", "变换外貌", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("隐蔽者", Camouflager.color, "在伪装下杀死船员", "在伪装下杀死船员", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("吸血鬼", Vampire.color, "吸血船员来杀死他们", "吸血船员来杀死他们", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("抹除者", Eraser.color, "抹除他人的职业", "抹除他人的职业", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("骗术师", Trickster.color, "惊不惊喜，意不意外？", "用你的骗术盒为其他玩家带来惊喜", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("清理者", Cleaner.color, "清理倒下的鸡腿", "清理尸体", RoleId.Cleaner);
        public static RoleInfo warlock = new RoleInfo("术士", Warlock.color, "诅咒并杀死所有人", "诅咒并杀死所有人", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("赏金猎人", BountyHunter.color, "追杀你的赏金目标", "追杀赏金目标", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("侦探", Detective.color, "通过调查脚印来找到<color=#FF1919FF>内鬼</color>", "检查脚印", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("时间领主", TimeMaster.color, "使用时间护盾保护自己", "使用时间护盾保护自己", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("医生", Medic.color, "使用护盾保护船员", "使用护盾保护船员", RoleId.Medic);
        public static RoleInfo shifter = new RoleInfo("交换师", Shifter.color, "换得他人的职业", "换得他人的职业", RoleId.Shifter);
        public static RoleInfo swapper = new RoleInfo("换票师", Swapper.color, "交换投票来放逐<color=#FF1919FF>内鬼</color>", "交换投票", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("灵媒", Seer.color, "可以感知其他玩家死亡", "可以感知其他玩家死亡", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("黑客", Hacker.color, "黑入系统来找到<color=#FF1919FF>内鬼</color>", "骇入来找到内鬼", RoleId.Hacker);
        public static RoleInfo tracker = new RoleInfo("追踪者", Tracker.color, "追踪<color=#FF1919FF>内鬼</color>", "追踪内鬼", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("密探", Snitch.color, "完成所有任务可找出<color=#FF1919FF>内鬼</color>", "完成所有任务", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("豺狼", Jackal.color, "杀死所有的船员和<color=#FF1919FF>内鬼</color>来获得胜利", "杀掉所有人", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("跟班", Sidekick.color, "帮助豺狼杀掉所有人", "帮助豺狼杀掉所有人", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("间谍", Spy.color, "迷惑<color=#FF1919FF>内鬼</color>", "迷惑内鬼", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("保安", SecurityGuard.color, "封锁管道，安放摄像头", "封锁管道，安放摄像头", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("纵火狂", Arsonist.color, "用火焰净化一切", "用火焰净化一切", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("正义的赌怪", Guesser.color, "生命就是豪赌", "生命就是豪赌", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("邪恶的赌怪", Palette.ImpostorRed, "生命就是豪赌", "生命就是豪赌", RoleId.EvilGuesser);
        public static RoleInfo vulture = new RoleInfo("秃鹫", Vulture.color, "吞噬尸体来获得胜利", "吞噬尸体", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("通灵师", Medium.color, "在死亡位置通灵获取信息", "通灵获取信息", RoleId.Medium);
        public static RoleInfo lawyer = new RoleInfo("律师", Lawyer.color, "为你的客户辩护", "为你的客户辩护", RoleId.Lawyer, true);
        public static RoleInfo pursuer = new RoleInfo("起诉人", Pursuer.color, "给内鬼塞空包弹，活下去", "给内鬼塞空包弹，活下去", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("内鬼", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "破坏或杀死所有人"), "破坏或杀死所有人", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("船员", Color.white, "找到内鬼", "找到内鬼", RoleId.Crewmate);
        public static RoleInfo witch = new RoleInfo("女巫", Witch.color, "对你的敌人施咒", "对你的敌人施咒", RoleId.Witch);
        public static RoleInfo ninja = new RoleInfo("忍者", Ninja.color, "出其不意暗杀敌人", "出其不意暗杀敌人", RoleId.Ninja);


        // Modifier
        public static RoleInfo bloody = new RoleInfo("血语者", Color.yellow, "杀死你的人将会留下血迹", "杀死你的人将会留下血迹", RoleId.Bloody, false, true);
        public static RoleInfo antiTeleport = new RoleInfo("通信兵", Color.yellow, "可以远程开会", "可以远程开会", RoleId.AntiTeleport, false, true);
        public static RoleInfo tiebreaker = new RoleInfo("破平着", Color.yellow, "平票时你的投票将算作两票", "打破平票", RoleId.Tiebreaker, false, true);
        public static RoleInfo bait = new RoleInfo("诱饵", Color.yellow, "杀死你的敌人将自己报告", "杀死你的敌人将自己报告", RoleId.Bait, false, true);
        public static RoleInfo sunglasses = new RoleInfo("弱视", Color.yellow, "你瞎了", "你的视野范围缩小了", RoleId.Sunglasses, false, true);
        public static RoleInfo lover = new RoleInfo("恋人", Lovers.color, $"你们相爱了", $"你们相爱了", RoleId.Lover, false, true);
        public static RoleInfo mini = new RoleInfo("迷你人", Color.yellow, "在你长大前没人可以杀死你", "没人可以伤害你", RoleId.Mini, false, true);
        public static RoleInfo vip = new RoleInfo("网红", Color.yellow, "你是网红", "所有人都会知道你死了", RoleId.Vip, false, true);
        public static RoleInfo invert = new RoleInfo("醉鬼", Color.yellow, "你的移动是反向的", "你的移动是反向的", RoleId.Invert, false, true);


        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            ninja,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            crewmate,
            shifter,
            mayor,
            portalmaker,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium,
            bloody,
            antiTeleport,
            tiebreaker,
            sunglasses,
            mini,
            vip,
            invert
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p, bool showModifier = true) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Modifier
            if (showModifier) {
                if (p == Lovers.lover1 || p == Lovers.lover2) infos.Add(lover);
                if (p == Tiebreaker.tiebreaker) infos.Add(tiebreaker);
                if (Bait.bait.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bait);
                if (Bloody.bloody.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bloody);
                if (AntiTeleport.antiTeleport.Any(x => x.PlayerId == p.PlayerId)) infos.Add(antiTeleport);
                if (Sunglasses.sunglasses.Any(x => x.PlayerId == p.PlayerId)) infos.Add(sunglasses);
                if (p == Mini.mini) infos.Add(mini);
                if (Vip.vip.Any(x => x.PlayerId == p.PlayerId)) infos.Add(vip);
                if (Invert.invert.Any(x => x.PlayerId == p.PlayerId)) infos.Add(invert);
            }

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Portalmaker.portalmaker) infos.Add(portalmaker);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Ninja.ninja) infos.Add(ninja);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Shifter.shifter) infos.Add(shifter);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer) infos.Add(lawyer);
            if (p == Pursuer.pursuer) infos.Add(pursuer);

            // Default roles
            if (infos.Count == 0 && p.Data.Role.IsImpostor) infos.Add(impostor); // Just Impostor
            if (infos.Count == 0 && !p.Data.Role.IsImpostor) infos.Add(crewmate); // Just Crewmate

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors, bool showModifier = true) {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p, showModifier).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && PlayerControl.LocalPlayer != Lawyer.target) roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            return roleName;
        }
    }
}
