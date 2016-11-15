//
// Copyright (c) 2015 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//


/*--- __ECO__ __UTOMATE__ __ACTION__
EcoMetaStart
{
"script dependancies":[
						"Assets/uTomate Ecosystem Actions/Editor/Web/OpenUrlInspector.cs"
					]
}
EcoMetaEnd
---*/

using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections;
#if UNITY_5
using AncientLightStudios.uTomate.API;
using AncientLightStudios.uTomate;
#endif

namespace Ecosystem.Utomate
{
	
	[UTActionInfo(actionCategory = "Files + Folders")]
	[UTDoc(title="Open File with Default Application", description="Open an File using the default Application")]
	[UTDefaultAction]
	/// <summary>
	/// Action that opens a file using the default Application.
	/// </summary>
	public class OpenFileWithDefaultApplication : UTAction
	{
		[UTDoc(description="File To open")]
		[UTInspectorHint(displayAs=UTInspectorHint.DisplayAs.Default, caption="Enter File Path", required=true)]
		public UTString filePath;
		
		public override IEnumerator Execute (UTContext context)
		{
			string _filePath = filePath.EvaluateIn (context);
			
			try 
			{
				System.Diagnostics.Process.Start(_filePath);
			}
			catch(Exception e) 
			{
				throw new UTFailBuildException("Opening File failed. " + e.Message,this);
			}
			
			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Files + Folders/Open File With Default Application")]
		public static void AddAction ()
		{
			Create<OpenFileWithDefaultApplication> ();
		}
		
	}
	
	[CustomEditor(typeof(OpenFileWithDefaultApplication))]
	public class OpenFileWithDefaultApplicationEditor : UTInspectorBase {}
}

