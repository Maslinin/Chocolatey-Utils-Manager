using System.Threading.Tasks;

namespace CUM.Chocolatey
{
    sealed class ChocoInstaller
    {
        internal ChocoBase ChocoChild { get; private set; }

        public ChocoInstaller() => ChocoChild = new ChocoBase();

        /// <summary>
        /// Устанавливает Chocolatey, если он не установлен
        /// </summary>
        /// <param name="auth"></param>
        internal async void ChocoInstall()
        {
            if (!ChocoChild.ChocoExists())
            {
                await Task.Run(() => ChocoChild.ChocoInstall());
            }
        }
        /// <summary>
        /// Устанавливает указзанный пакет Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async void InstallPackage(string packageLinkName)
        {
            if (ChocoChild.ChocoExists())
            {
                await Task.Run(() => ChocoChild.InstallPackage(packageLinkName));
            }
        }
        /// <summary>
        /// Обновляет указанный пакет Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async void UpdatePackage(string packageLinkName)
        {
            if (ChocoChild.ChocoExists())
            {
                await Task.Run(() => ChocoChild.UpdatePackage(packageLinkName));
            }
        }
        /// <summary>
        /// Удаляет указанный пакет Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async void UpdateDelete(string packageLinkName)
        {
            if (ChocoChild.ChocoExists())
            {
                await Task.Run(() => ChocoChild.DeletePackage(packageLinkName));
            }
        }
    }
}
