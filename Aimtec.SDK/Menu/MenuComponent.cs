﻿namespace Aimtec.SDK.Menu
{
    using System;
    using System.Drawing;

    using Aimtec.SDK.Menu.Theme;

    /// <summary>
    ///     Class MenuComponent.
    /// </summary>
    /// <seealso cref="Aimtec.SDK.Menu.IMenuComponent" />
    public abstract class MenuComponent : IMenuComponent
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public abstract string DisplayName { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="MenuComponent" /> is enabled.
        /// </summary>
        /// <remarks>
        ///     This property will only succeed if the MenuComponent implements <see cref="IReturns{bool}" />.
        /// </remarks>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled => ((IReturns<bool>) this).Value;

        /// <summary>
        ///     Gets or sets the name of the internal.
        /// </summary>
        /// <value>The name of the internal.</value>
        public virtual string InternalName { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public abstract Vector2 Position { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="IMenuComponent" /> is toggled.
        /// </summary>
        /// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        public abstract bool Toggled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="IMenuComponent" /> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public abstract bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public abstract Menu Parent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MenuComponent"/> is the root menu.
        /// </summary>
        /// <value><c>true</c> if this menu is the root menu; otherwise, <c>false</c>.</value>
        public abstract bool Root { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is a menu.
        /// </summary>
        /// <value><c>true</c> if this instance is a menu; otherwise, <c>false</c>.</value>
        public virtual bool IsMenu => false;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Converts the <see cref="MenuComponent" /> to the specified <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T As<T>() where T : MenuComponent
        {
            return (T) this;
        }

        /// <summary>
        ///     Gets the bounds.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Drawing.Rectangle.</returns>
        public virtual Rectangle GetBounds(Vector2 pos)
        {
            return new Rectangle(
                (int) pos.X,
                (int) pos.Y,
                this.Root ? MenuManager.Instance.Theme.RootMenuWidth : MenuManager.Instance.Theme.ComponentWidth,
                MenuManager.Instance.Theme.MenuHeight);
        }



        /// <summary>
        ///     Gets the render manager.
        /// </summary>
        /// <returns>Aimtec.SDK.Menu.Theme.IRenderManager.</returns>
        public abstract IRenderManager GetRenderManager();

        /// <summary>
        ///     Renders at the specified position.
        /// </summary>
        /// <param name="pos">The position.</param>
        public virtual void Render(Vector2 pos)
        {
            if (this.Visible)
            {
                this.GetRenderManager().Render(pos);
            }
        }

        /// <summary>
        ///     An application-defined function that processes messages sent to a window.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="wparam">Additional message information.</param>
        /// <param name="lparam">Additional message information.</param>
        public virtual void WndProc(uint message, uint wparam, int lparam)
        {
        }

        /// <summary>
        /// Gets the <see cref="MenuComponent"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>MenuComponent.</returns>
        public MenuComponent this[string name] => ((Menu)(IMenu)(IMenuComponent) this)[name];

        #endregion
    }
}