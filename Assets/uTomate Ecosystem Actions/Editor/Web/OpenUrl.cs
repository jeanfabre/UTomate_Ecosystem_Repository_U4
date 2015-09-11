﻿//
// Copyright (c) 2013 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//


/*--- __UTOMATE__ __UTACTION__
EcoMetaStart
{
"script dependancies":[
						"Assets/uTomate Ecosystem Actions/Editor/OpenUrlInspector.cs"
					]
}
EcoMetaEnd
---*/

using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections;


namespace Ecosystem.Utomate
{

	[UTActionInfo(actionCategory = "Web", sinceUTomateVersion="1.2.0")]
	[UTDoc(title="Open Url ", description="Open an Url using the default Web Browser")]
	[UTDefaultAction]
	/// <summary>
	/// Action that opens a url using the default browser.
	/// </summary>
	public class OpenUrl : UTAction
	{
		[UTDoc(description="Url To open")]
		[UTInspectorHint(displayAs=UTInspectorHint.DisplayAs.Default, caption="Enter Url", required=true)]
		public UTString url;
		
		public override IEnumerator Execute (UTContext context)
		{
			string realUrl = url.EvaluateIn (context);
			
			try 
			{
				Application.OpenURL(realUrl);
			}
			catch(Exception e) 
			{
				throw new UTFailBuildException("Opening Url failed. " + e.Message,this);
			}
			
			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Web/Open Url")]
		public static void AddAction ()
		{
			Create<OpenUrl> ();
		}
		
	}

}
