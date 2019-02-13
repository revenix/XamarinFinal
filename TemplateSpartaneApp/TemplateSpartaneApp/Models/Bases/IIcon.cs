﻿using System;

namespace TemplateSpartaneApp.Models.Bases
{
    /// <summary>
    /// Icon represents one icon in an icon font.
    /// </summary>
    public interface IIcon
    {
        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        /// <returns></returns>
        Char Character { get; }

        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        /// <returns></returns>
        String Key { get; }
    }
}
