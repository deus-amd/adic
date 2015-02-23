﻿using UnityEngine;
using System.Collections;

namespace Intentor.Adic.Examples.Prefabs {
	/// <summary>
	/// Cube rotator script.
	/// </summary>
	public class CubeRotator : MonoBehaviour {
		[Inject("cube")]
		public Transform cube;

		/// <summary>Messages to show on screen.</summary>
		private string messages;

		/// <summary>
		/// Called after all injections.
		/// </summary>
		[PostConstruct]
		protected void PostConstruct() {
			//Setup some messages.
			this.messages = string.Concat(this.messages, "PostConstruct called.", System.Environment.NewLine);
			var cubeInjected = (this.cube == null ? "No..." : "Yes!");
			this.messages = string.Concat(this.messages, "Cube injected? " + cubeInjected, System.Environment.NewLine);
		}

		/// <summary>
		/// Start is called after PostConstruct.
		/// </summary>
		protected void Start() {
			//Calls "Inject" to inject any dependencies to the component.
			//On a productin game, it's useful to place this in a base component.
			this.Inject();
		}

		protected void Update () {
			this.cube.Rotate(1.0f, 1.0f, 1.0f);
		}

		protected void OnGUI() {
			GUI.Label(new Rect(10, 10, 300, 100), this.messages);
		}
	}
}