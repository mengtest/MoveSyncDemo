﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FairyGUI_GoWrapperWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FairyGUI.GoWrapper), typeof(FairyGUI.DisplayObject));
		L.RegFunction("CacheRenderers", CacheRenderers);
		L.RegFunction("Update", Update);
		L.RegFunction("Dispose", Dispose);
		L.RegFunction("New", _CreateFairyGUI_GoWrapper);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("supportStencil", get_supportStencil, set_supportStencil);
		L.RegVar("onUpdate", get_onUpdate, set_onUpdate);
		L.RegVar("wrapTarget", get_wrapTarget, set_wrapTarget);
		L.RegVar("renderingOrder", get_renderingOrder, set_renderingOrder);
		L.RegVar("layer", get_layer, set_layer);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFairyGUI_GoWrapper(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FairyGUI.GoWrapper obj = new FairyGUI.GoWrapper();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				FairyGUI.GoWrapper obj = new FairyGUI.GoWrapper(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FairyGUI.GoWrapper.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CacheRenderers(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)ToLua.CheckObject<FairyGUI.GoWrapper>(L, 1);
			obj.CacheRenderers();
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
			ToLua.CheckArgsCount(L, 2);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)ToLua.CheckObject<FairyGUI.GoWrapper>(L, 1);
			FairyGUI.UpdateContext arg0 = (FairyGUI.UpdateContext)ToLua.CheckObject<FairyGUI.UpdateContext>(L, 2);
			obj.Update(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dispose(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)ToLua.CheckObject<FairyGUI.GoWrapper>(L, 1);
			obj.Dispose();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportStencil(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			bool ret = obj.supportStencil;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index supportStencil on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onUpdate(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			FairyGUI.EventCallback0 ret = obj.onUpdate;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index onUpdate on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapTarget(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			UnityEngine.GameObject ret = obj.wrapTarget;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index wrapTarget on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingOrder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			int ret = obj.renderingOrder;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index renderingOrder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			int ret = obj.layer;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index layer on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_supportStencil(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.supportStencil = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index supportStencil on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onUpdate(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			FairyGUI.EventCallback0 arg0 = (FairyGUI.EventCallback0)ToLua.CheckDelegate<FairyGUI.EventCallback0>(L, 2);
			obj.onUpdate = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index onUpdate on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapTarget(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 2, typeof(UnityEngine.GameObject));
			obj.wrapTarget = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index wrapTarget on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderingOrder(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.renderingOrder = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index renderingOrder on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layer(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FairyGUI.GoWrapper obj = (FairyGUI.GoWrapper)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.layer = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index layer on a nil value");
		}
	}
}

