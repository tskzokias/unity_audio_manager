# Unity Audio Manager
- A comprehensive Unity Audio Manager leveraging ScriptableObjects to store Sound Effects (SFX) and Background Music (BGM), providing robust audio management for any Unity game. This Audio Manager includes advanced sound control features such as fade in, fade out, volume adjustment, mute, play, and pause functionalities.

## Features
- **ScriptableObject-based Audio Management**
- Store and organize SFX and BGM using ScriptableObjects for easy management and reuse across projects.

- **Advanced Audio Controls**
  - **Fade In/Out**: Smoothly transition audio in and out for seamless audio experiences.
  - **Volume Adjustment**: Easily control the volume of SFX and BGM individually.
  - **Mute/Unmute**: Toggle audio mute state for both SFX and BGM.
  - **Play/Pause/Stop**: Control playback state for precise audio timing.

## Getting Started
### Prerequisites

- Unity 2020.3 or later

### Installation

1. **Clone the Repository**:
       git clone https://github.com/your-username/unity-audio-manager.git
2. **Import into Unity**:
       Open your Unity project and import the cloned repository.

### Setup

1. **Create ScriptableObjects**:
        Create a new AudioClipLibrarySO ScriptableObject for your SFX and BGM.
        Assign audio clips to the SerializableDictionary<string, AudioClip> in the ScriptableObject.

2. **Assign Audio Sources**:
        In the Unity Editor, attach the AudioManager script to a GameObject (e.g., an empty GameObject named AudioManager).
        Assign the BGM and SFX AudioSource components to the AudioManager.
        Assign the AudioClipLibrarySO ScriptableObjects to the AudioManager.
