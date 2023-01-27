using Project.Scripts.Game.Base;
using Zenject;

public class Entry : MonoInstaller<Entry>
{
    public override void InstallBindings()
    {
        BaseInstaller.Install(Container);
    }
}
