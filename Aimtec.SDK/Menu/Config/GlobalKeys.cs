namespace Aimtec.SDK.Menu.Config
{
    using Aimtec.SDK.Menu.Components;
    using Aimtec.SDK.Util;

    using NLog.Fluent;

    public class GlobalKeys
    {
        #region Static Fields

        internal static Menu KeyConfig;

        #endregion

        #region Public Properties

        public static GlobalKey BurstKey { get; set; }

        //Main Keys - To be enabled by default
        public static GlobalKey ComboKey { get; set; }

        public static GlobalKey ComboNoOrbwalkKey { get; set; }

        public static GlobalKey FleeKey { get; set; }

        public static GlobalKey FreezeKey { get; set; }

        //Additional Keys that can be enabled by assemblies if they require it
        public static GlobalKey HarassKey { get; set; }

        public static GlobalKey LastHitKey { get; set; }

        public static GlobalKey MixedKey { get; set; }

        public static GlobalKey TowerDiveKey { get; set; }

        public static GlobalKey WaveClearKey { get; set; }

        #endregion

        #region Methods

        internal static void Load()
        {
            Log.Info().Message("Loading Global Keys").Write();

            KeyConfig = new Menu("Keys", "按鍵");

            KeyConfig.Add(new MenuSeperator("seperator", "走砍 按鍵"));

            ComboKey = new GlobalKey("Combo", "連招", KeyCode.Space, KeybindType.Press, true);
            MixedKey = new GlobalKey("Mixed", "騷擾清線", KeyCode.C, KeybindType.Press, true);
            WaveClearKey = new GlobalKey("WaveClear", "清線", KeyCode.V, KeybindType.Press, true);
            LastHitKey = new GlobalKey("LastHit", "尾兵", KeyCode.X, KeybindType.Press, true);

            KeyConfig.Add(new MenuSeperator("seperator2", "額外按鍵"));

            HarassKey = new GlobalKey("Harass", "騷擾", KeyCode.H, KeybindType.Toggle, false);
            FreezeKey = new GlobalKey("Freeze", "控線", KeyCode.M, KeybindType.Toggle, false);
            BurstKey = new GlobalKey("Burst", "爆發", KeyCode.K, KeybindType.Press, false);
            FleeKey = new GlobalKey("Flee", "逃跑", KeyCode.Z, KeybindType.Press, false);
            TowerDiveKey = new GlobalKey("TowerDive", "翻牆", KeyCode.T, KeybindType.Press, false);

            ComboNoOrbwalkKey = new GlobalKey(
                "ComboNoOrbwalk",
                "連招 - 不走砍",
                KeyCode.J,
                KeybindType.Toggle,
                false);

            AimtecMenu.Instance.Add(KeyConfig);
        }

        #endregion
    }

    public class GlobalKey
    {
        #region Constructors and Destructors

        internal GlobalKey(string internalName, string displayName, KeyCode keyCode, KeybindType type, bool enabled)
        {
            this.KeyBindItem = new MenuKeyBind(internalName, displayName, keyCode, type);

            if (enabled)
            {
                this.Activate();
            }
        }

        #endregion

        #region Public Properties

        //Gets whether the keybind is active
        public bool Active
        {
            get
            {
                if (!this.AddedToMenu)
                {
                    this.Activate();
                }

                return this.KeyBindItem.Value;
            }
        }

        //The Menu item associated with this Key
        public MenuKeyBind KeyBindItem { get; }

        #endregion

        #region Properties

        private bool AddedToMenu { get; set; }

        #endregion

        #region Public Methods and Operators

        //Enables the key by adding it to the keylist
        public void Activate()
        {
            if (!this.AddedToMenu)
            {
                GlobalKeys.KeyConfig.Add(this.KeyBindItem);
                this.AddedToMenu = true;
            }
        }

        #endregion
    }
}