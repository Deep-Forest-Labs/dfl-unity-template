#nullable enable
using DeepForestLabs;
using DeepForestLabs.Audio;
using DeepForestLabs.Factories;
using UnityEngine;

namespace GameName.Factories {
    public sealed class AppContainerFactory : ContainerBuilderFactory
    {
        [SerializeField] private AudioMixerConfig _audioMixerConfig = default!;
        [SerializeField] private SoundCatalog? _soundCatalog;

        public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
        {
            return builder
                .AddAudioService(_audioMixerConfig, _soundCatalog)
                .AddTransient<AppState>();
        }
    }
}
#nullable disable
