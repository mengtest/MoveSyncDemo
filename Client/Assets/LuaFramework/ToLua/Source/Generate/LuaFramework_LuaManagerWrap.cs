﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaFramework_LuaManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaFramework.LuaManager), typeof(Manager));
		L.RegFunction("InitStart", InitStart);
		L.RegFunction("DoFile", DoFile);
		L.RegFunction("CallFunction", CallFunction);
		L.RegFunction("GetFunction", GetFunction);
		L.RegFunction("LuaGC", LuaGC);
		L.RegFunction("Close", Close);
		L.RegFunction("Update", Update);
		L.RegFunction("LateUpate", LateUpate);
		L.RegFunction("FixedUpdate", FixedUpdate);
		L.RegFunction("OnLevelLoaded", OnLevelLoaded);
		L.RegFunction("GetStaticDataTable", GetStaticDataTable);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitStart(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.InitStart();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.DoFile(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallFunction(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			object[] arg1 = ToLua.ToParamsObject(L, 3, count - 2);
			object[] o = obj.CallFunction(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFunction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			LuaInterface.LuaFunction o = obj.GetFunction(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaGC(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.LuaGC();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Close(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.Close();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.Update();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LateUpate(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.LateUpate();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FixedUpdate(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			obj.FixedUpdate();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnLevelLoaded(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.OnLevelLoaded(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStaticDataTable(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaFramework.LuaManager obj = (LuaFramework.LuaManager)ToLua.CheckObject<LuaFramework.LuaManager>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			LuaInterface.LuaTable o = obj.GetStaticDataTable(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

