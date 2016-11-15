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
	[UTDoc(title="Play Current Scene", description="Starts Playing the current Scene")]
	[UTDefaultAction]
	/// <summary>
	/// Action that starts playing.
	/// </summary>
	public class StartPlaying : UTAction
	{
		
		public override IEnumerator Execute (UTContext context)
		{

			try 
			{
				EditorApplication.SaveCurrentSceneIfUserWantsTo();

				EditorApplication.isPlaying = true;
			}
			catch(Exception e) 
			{
				throw new UTFailBuildException("StartPlaying Scene failed. " + e.Message,this);
			}
			
			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Editor/StartPlaying")]
		public static void AddAction ()
		{
			Create<StartPlaying> ();
		}
		
	}

}
