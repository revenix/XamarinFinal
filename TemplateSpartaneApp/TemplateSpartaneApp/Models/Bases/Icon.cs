namespace TemplateSpartaneApp.Models.Bases
{
    /// <summary>
    /// Defines the <see cref="Icon" /> type.
    /// </summary>
    /// <seealso cref="IIcon" />
    public class Icon : IIcon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Icon" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="character">The character.</param>
        public Icon(string key, char character)
        {
            Character = character;
            Key = key;
        }

        /// <summary>
        /// The character matching the key in the font, for example '\u4354'
        /// </summary>
        public char Character { get; private set; }

        /// <summary>
        /// The key of icon, for example 'fa-ok'
        /// </summary>
        public string Key { get; private set; }
    }
}
