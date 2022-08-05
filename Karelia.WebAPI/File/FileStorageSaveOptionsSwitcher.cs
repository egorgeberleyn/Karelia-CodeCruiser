using System;
using BusinessFramework.WebAPI.Contracts.Files.Storage;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI.Contracts;


namespace Karelia.WebAPI.File
{
    /// <inheritdoc />
    public sealed class FileStorageSaveOptionsSwitcher : FileStorageSaveOptionsSwitcherBase
    {
        private readonly IScope _scope;

        /// <inheritdoc />
        public FileStorageSaveOptionsSwitcher(IScope scope)
        {
            _scope = scope;
        }

        /// <inheritdoc />
        protected override IFileStorageSaveOptionsResolver GetResolver(int fieldId)
        {
            switch (fieldId)
            {
                default:
                    throw new ArgumentOutOfRangeException(nameof(fieldId), $"Unknown fieldId={fieldId}");
            }
        }
    }
}