//
// Copyright (c) 2015 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//

//__ECO__ __UTOMATE__ __ACTION__

using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.ComponentModel;
using System.Collections;
#if UNITY_5
using AncientLightStudios.uTomate.API;
using AncientLightStudios.uTomate;
#endif

namespace Ecosystem.Utomate
{
	
	[UTDoc(title="Copy File", description="Copy a File")]
	[UTActionInfo(actionCategory="Files + Folders")]
	public class CopyFile : UTAction
	{
		
		[UTInspectorHint(required=true, order=0)]
		[UTDoc(description="The file to duplicate")]
		public UTString filePath;
		
		[UTInspectorHint(required=true, order=1)]
		[UTDoc(description="the duplicated filePath to copy filePath into")]
		public UTString duplicateFilePath;
		
		[UTInspectorHint(required=true, order=2)]
		[UTDoc(description="if true and duplicateFilePath exists already, file will be overwritten")]
		public UTBool overwrite;
		
		public override IEnumerator Execute (UTContext context)
		{
			string _filePath = filePath.EvaluateIn (context);
			string _duplicateFilePath = duplicateFilePath.EvaluateIn (context);
			bool _overwrite = overwrite.EvaluateIn (context);

			File.Copy(_filePath, _duplicateFilePath,_overwrite);

			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Files + Folders/Copy File", false)]
		public static void AddAction() {
			Create<CopyFile>();
		}
	}
	
	
	[CustomEditor(typeof(CopyFile))]
	public class CopyFileEditor : UTInspectorBase {}
	
}


