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

namespace Ecosystem.Utomate
{
	
	[UTDoc(title="Find and Replace In File", description="Find and Replace Text in Text File")]
	[UTActionInfo(actionCategory="Files + Folders")]
	public class FindAndReplaceInTextFile : UTAction
	{
		
		[UTInspectorHint(required=true, order=0)]
		[UTDoc(description="The file pat")]
		public UTString filePath;
		
		[UTInspectorHint(required=true, order=1)]
		[UTDoc(description="the string to be replaced")]
		public UTString oldValue;
		
		[UTInspectorHint(required=true, order=2)]
		[UTDoc(description="the string to replace all occurences of 'oldValue'")]
		public UTString newValue;
		
		public override IEnumerator Execute (UTContext context)
		{
			string _filePath = filePath.EvaluateIn (context);
			string _oldValue = oldValue.EvaluateIn (context);
			string _newValue = newValue.EvaluateIn (context);

			string _content = File.ReadAllText(_filePath);
		
			string _newContent = _content.Replace(_oldValue,_newValue);

			File.WriteAllText(_filePath, _newContent);

			yield return "";
		}
		
		[MenuItem("Assets/Create/uTomate/Files + Folders/Find And Replace In Text File", false)]
		public static void AddAction() {
			Create<FindAndReplaceInTextFile>();
		}
	}
	
	
	[CustomEditor(typeof(FindAndReplaceInTextFile))]
	public class FindAndReplaceInTextFileEditor : UTInspectorBase {}
	
}


