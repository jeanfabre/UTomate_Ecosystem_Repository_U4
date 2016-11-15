//
// Copyright (c) 2015 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//


/*--- __ECO__ __UTOMATE__ __ACTION__ ---*/

using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections;


namespace Ecosystem.Utomate
{

	[UTActionInfo(actionCategory = "Editor", sinceUTomateVersion="1.2.0")]
	[UTDoc(title="Stop Playing Scene", description="Stops Editor Playback")]
	[UTDefaultAction]
	/// <summary>
	/// Action that stops playing.
	/// </summary>
	public class StopPlaying : UTAction
	{
		
		public override IEnumerator Execute (UTContext context)
		{

			try 
			{
				EditorApplication.isPlaying = false;
			}
			catch(Exception e) 
			{
				throw new UTFailBuildException("StopPlaying failed. " + e.Message,this);
			}
			
			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Editor/Stop Playing")]
		public static void AddAction ()
		{
			Create<StopPlaying> ();
		}
		
	}

}
