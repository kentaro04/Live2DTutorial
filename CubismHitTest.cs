﻿using UnityEngine;
using Live2D.Cubism.Framework.Raycasting;

public class CubismHitTest : MonoBehaviour
{

	private void Update()
	{
		// Return early in case of no user interaction.
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}


		var raycaster = GetComponent<CubismRaycaster>();
		// Get up to 4 results of collision detection.
		var results = new CubismRaycastHit[4];


		// Cast ray from pointer position.
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var hitCount = raycaster.Raycast(ray, results);


		// Show results.
		var resultsText = hitCount.ToString();
		for (var i = 0; i < hitCount; i++)
		{
			resultsText += "\n" + results[i].Drawable.name;
			PlayAnimation(results[i].Drawable.name);			// 追加
		}


		Debug.Log(resultsText);
	}

	// ここから追加
	Animator animator;
	void Start() {
		animator = GetComponent<Animator>();
	}

	void PlayAnimation(string inString ) {
		switch ( inString ) {
		case "ArtMesh":	// Drawables -> ArtMesh に CubismRaycastable がアタッチされているとここにきます。
			animator.CrossFade("Motion1",0.1f);	// 0.1秒かけて単にクロスフェードするので、メカニム(ステートマシン)を使った方がいいですがとりあえず一番簡単な方法で...
			break;
		case "ArtMesh77":
			animator.CrossFade("Motion2",0.1f);
			break;
		default:
			animator.CrossFade("idle",1f);
			break;
		}
	}
}

