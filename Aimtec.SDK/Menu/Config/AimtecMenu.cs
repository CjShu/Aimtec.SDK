namespace Aimtec.SDK.Menu.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Aimtec.SDK.Menu.Components;
    using Aimtec.SDK.Utils;

    using NLog.Fluent;

    internal class AimtecMenu : Menu
    {
        #region Constructors and Destructors

        internal AimtecMenu()
            : base("Aimtec.Menu", "Aimtec", true)
        {
            this.Add(new MenuBool("Aimtec.Debug", "開發調適模式", false, true));

            Log.Info().Message("Aimtec menu created").Write();
        }

        #endregion

        #region Properties

        internal static bool DebugEnabled => Instance["Aimtec.Debug"].Enabled;

        internal static AimtecMenu Instance { get; } = new AimtecMenu();

        #endregion
    }
}