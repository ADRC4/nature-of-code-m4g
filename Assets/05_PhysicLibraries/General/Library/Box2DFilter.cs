using UnityEngine;
using System.Linq;
using System.Collections;
using Box2DX.Dynamics;

using FilterData = Box2DX.Dynamics.FilterData;

public class Box2DFilter : MonoBehaviour {
	
	public static implicit operator FilterData(Box2DFilter box2DFilter)
	{
		FilterData filter;
		
		filter.CategoryBits = 0;		
		for(int index = 0; index < 16; ++index) 
		{
			filter.CategoryBits |= (ushort)((box2DFilter.CategoryBits[index] ? 1 : 0) << index);
		}
		
		filter.MaskBits = 0;
		for (int index = 0; index < 16; ++index) 
		{
			filter.MaskBits |= (ushort)((box2DFilter.MaskBits[index] ? 1 : 0) << index);
		}
		
		filter.GroupIndex = (short)box2DFilter.groupIndex;
		return filter;
	}
	
	public bool[] CategoryBits = new bool[16] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false  };
	public bool[] MaskBits = new bool[16] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true  };
	
	public int groupIndex = 0;
	
}
