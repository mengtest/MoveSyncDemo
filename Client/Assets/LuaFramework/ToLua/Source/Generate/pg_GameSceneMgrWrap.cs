﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class pg_GameSceneMgrWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(pg.GameSceneMgr), typeof(Manager));
		L.RegFunction("OnInit", OnInit);
		L.RegFunction("CallLuaFunc", CallLuaFunc);
		L.RegFunction("OnReceiveLuaTable", OnReceiveLuaTable);
		L.RegFunction("Update", Update);
		L.RegFunction("RegisterCallback", RegisterCallback);
		L.RegFunction("UnRegisterCallback", UnRegisterCallback);
		L.RegFunction("DoEvent", DoEvent);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("LuaEventHandle", get_LuaEventHandle, set_LuaEventHandle);
		L.RegVar("Instance", get_Instance, null);
		L.RegFunction("PgEventHandler", pg_GameSceneMgr_PgEventHandler);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnInit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			obj.OnInit();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallLuaFunc(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			pg.EventEnum arg0 = (pg.EventEnum)ToLua.CheckObject(L, 2, typeof(pg.EventEnum));
			object[] arg1 = ToLua.ToParamsObject(L, 3, count - 2);
			obj.CallLuaFunc(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnReceiveLuaTable(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			obj.OnReceiveLuaTable(arg0, arg1);
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
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			obj.Update();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterCallback(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			pg.EventEnum arg0 = (pg.EventEnum)ToLua.CheckObject(L, 2, typeof(pg.EventEnum));
			pg.GameSceneMgr.PgEventHandler arg1 = (pg.GameSceneMgr.PgEventHandler)ToLua.CheckDelegate<pg.GameSceneMgr.PgEventHandler>(L, 3);
			obj.RegisterCallback(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnRegisterCallback(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
			pg.EventEnum arg0 = (pg.EventEnum)ToLua.CheckObject(L, 2, typeof(pg.EventEnum));
			pg.GameSceneMgr.PgEventHandler arg1 = (pg.GameSceneMgr.PgEventHandler)ToLua.CheckDelegate<pg.GameSceneMgr.PgEventHandler>(L, 3);
			obj.UnRegisterCallback(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoEvent(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
				pg.EventEnum arg0 = (pg.EventEnum)ToLua.CheckObject(L, 2, typeof(pg.EventEnum));
				obj.DoEvent(arg0);
				return 0;
			}
			else if (count == 3)
			{
				pg.GameSceneMgr obj = (pg.GameSceneMgr)ToLua.CheckObject<pg.GameSceneMgr>(L, 1);
				pg.EventEnum arg0 = (pg.EventEnum)ToLua.CheckObject(L, 2, typeof(pg.EventEnum));
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.DoEvent(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: pg.GameSceneMgr.DoEvent");
			}
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaEventHandle(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)o;
			LuaInterface.LuaFunction ret = obj.LuaEventHandle;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LuaEventHandle on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		try
		{
			ToLua.Push(L, pg.GameSceneMgr.Instance);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaEventHandle(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			pg.GameSceneMgr obj = (pg.GameSceneMgr)o;
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.LuaEventHandle = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LuaEventHandle on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int pg_GameSceneMgr_PgEventHandler(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<pg.GameSceneMgr.PgEventHandler>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<pg.GameSceneMgr.PgEventHandler>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

