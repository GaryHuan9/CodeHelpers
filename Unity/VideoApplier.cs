#if CODEHELPERS_UNITY

using CodeHelpers.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace CodeHelpers.Unity
{
	[RequireComponent(typeof(VideoPlayer), typeof(RawImage))]
	public class VideoApplier : MonoBehaviour
	{
		void Awake()
		{
			player = GetComponent<VideoPlayer>();
			destination = GetComponent<RawImage>();

			player.frame = startFrameOffset;
			player.started += OnStart;
		}

		[SerializeField] int startFrameOffset;

		VideoPlayer player;
		RawImage destination;

		void Start()
		{
			OnStart(null);
		}

		void OnStart(VideoPlayer _)
		{
			if (!NeedToApply()) return;
			ApplyVideo();
		}

		bool NeedToApply() => player.texture == destination.texture;

		void ApplyVideo()
		{
			if (player.clip == null)
			{
				DebugHelper.Log("No clip assigned to video player");
				return;
			}

			VideoClip clip = player.clip;
			RenderTexture texture = new RenderTexture((int)clip.width, (int)clip.height, 0, RenderTextureFormat.ARGB32);

			destination.texture = texture;

			player.targetTexture = texture;
			player.renderMode = VideoRenderMode.RenderTexture;
		}
	}
}

#endif