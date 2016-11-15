//
// Copyright (c) 2013 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//

using System;
using UnityEditor;
#if UNITY_5
using AncientLightStudios.uTomate.API;
using AncientLightStudios.uTomate;
#endif

namespace Ecosystem.Utomate
{
	[CustomEditor(typeof(OpenUrl))]
	public class OpenUrlInspector : UTInspectorBase
	{
	}
}
