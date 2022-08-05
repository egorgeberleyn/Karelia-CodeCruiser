using System.Collections.Generic;
using BusinessFramework.Contracts.Formatting;

namespace Karelia.WebAPI
{
    /// <summary>
    /// Value formatting service
    /// </summary>
    public sealed class ValueFormattingService : BaseValueFormattingService
    {
        private readonly ValueFormatting[] _formats;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ValueFormattingService()
        {
            _formats = new[]
            {
                new ValueFormatting {Key = 0, Name = @"currency", DisplayName = @"Currency", Format = @"0,0[.]00 $"},
                new ValueFormatting {Key = 1, Name = @"shortdate", DisplayName = @"Short date", Format = @"DD.MM.YYYY"},
                new ValueFormatting {Key = 2, Name = @"shortdatetime", DisplayName = @"Short date and time", Format = @"DD.MM.YYYY HH:mm"},
                new ValueFormatting {Key = 3, Name = @"shorttime", DisplayName = @"Short time", Format = @"HH:mm"},
                new ValueFormatting {Key = 4, Name = @"year", DisplayName = @"Year", Format = @"YYYY"},
            };
        }

        /// <summary>
        ///     Get all value formats
        /// </summary>
        public override IReadOnlyCollection<ValueFormatting> Formats
        {
            get { return _formats; }
        }
    }
}