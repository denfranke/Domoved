﻿#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};

struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41;
struct InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56;
struct UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral20353326ACF03BB4112F3080DBCA0AC47DBC7BB2;
IL2CPP_EXTERN_C String_t* _stringLiteral9802A0C242B6B1F11EC74461BB2DF09CE62B8035;
IL2CPP_EXTERN_C String_t* _stringLiteralE7D028CCE3B6E7B61AE2C752D7AE970DA04AB7C6;
IL2CPP_EXTERN_C String_t* _stringLiteralECBE14D0ACE36FACE92343327DF7DFEC932523A5;
IL2CPP_EXTERN_C const RuntimeMethod* NSUserDefaults_GetString_mA77E63188B222653CB1C8AA0B0CB089F7EE0690E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NSUserDefaults_SetString_m0BFB3A66E345CE80C080620675028FDE686166F0_RuntimeMethod_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_tC6F3BE26E8DBB3B8108F8360B026950D37DAF754 
{
};
struct InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873  : public RuntimeObject
{
	String_t* ___Identifier;
	RuntimeObject* ___UnityAdsIdentifierProvider;
	RuntimeObject* ___UnityAnalyticsIdentifierProvider;
};
struct NSUserDefaults_t518A0A24332EC9EC2361F2C04C06166E301FF25C  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56  : public RuntimeObject
{
};
struct UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Guid_t 
{
	int32_t ____a;
	int16_t ____b;
	int16_t ____c;
	uint8_t ____d;
	uint8_t ____e;
	uint8_t ____f;
	uint8_t ____g;
	uint8_t ____h;
	uint8_t ____i;
	uint8_t ____j;
	uint8_t ____k;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName;
};
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct Guid_t_StaticFields
{
	Guid_t ___Empty;
};
struct Exception_t_StaticFields
{
	RuntimeObject* ___s_EDILock;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAdsIdentifier__ctor_mFD5085EB0AD902D689B820D13D697CE640E2E7B8 (UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAnalyticsIdentifier__ctor_mE19B73CB1414B5AC0619E8EF1366C0164B06D14B (UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478 (String_t* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InstallationId_CreateIdentifier_mC089486FCD96983C9186689C41D1D75E36EFB90C (InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* InstallationId_ReadIdentifierFromFile_m126AF7B4F947DBB382AA8848D51FEA52C91C3E7C (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* InstallationId_GenerateGuid_m7220D8C5AE5B4DCA4F4C01A6F921FF66C23E855A (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InstallationId_WriteIdentifierToFile_m67273AD8773FDBEE468B0BB7F502B3383AB9A6C4 (String_t* ___0_identifier, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* PlayerPrefs_GetString_mA4C9F842BF77E5572AB20EA087C7048F870D02AE (String_t* ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256 (String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Guid_t Guid_NewGuid_m1F4894E8DC089811D6252148AD5858E58D43A7BD (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Guid_ToString_m2BFFD5FA726E03FA707AAFCCF065896C46D5290C (Guid_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___0_paramName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NSUserDefaults_UserDefaultsGetString_m92C7603D4E38B141A88AC3E2B87B1DF1600A06A8 (String_t* ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NSUserDefaults_UserDefaultsSetString_m6D339E36904A6238646E398703ED1CB13D09BA83 (String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UnityAdsIdentifier_get_IdentifierForInstallIos_m510AD72EA3847591D1F1AE3214FE4E81A258092E (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAdsIdentifier_set_IdentifierForInstallIos_mD9D71B7910AA0380D1C5E9445A04B6E812C5F835 (String_t* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NSUserDefaults_GetString_mA77E63188B222653CB1C8AA0B0CB089F7EE0690E (String_t* ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NSUserDefaults_SetString_m0BFB3A66E345CE80C080620675028FDE686166F0 (String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C char* DEFAULT_CALL UOCPUserDefaultsGetString(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL UOCPUserDefaultsSetString(char*, char*);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InstallationId__ctor_mD8E8D5B7A72C54F2517D33F9F2C89FA708CC6BF7 (InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56* L_0 = (UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56*)il2cpp_codegen_object_new(UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56_il2cpp_TypeInfo_var);
		UnityAdsIdentifier__ctor_mFD5085EB0AD902D689B820D13D697CE640E2E7B8(L_0, NULL);
		__this->___UnityAdsIdentifierProvider = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___UnityAdsIdentifierProvider), (void*)L_0);
		UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D* L_1 = (UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D*)il2cpp_codegen_object_new(UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D_il2cpp_TypeInfo_var);
		UnityAnalyticsIdentifier__ctor_mE19B73CB1414B5AC0619E8EF1366C0164B06D14B(L_1, NULL);
		__this->___UnityAnalyticsIdentifierProvider = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___UnityAnalyticsIdentifierProvider), (void*)L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* InstallationId_GetOrCreateIdentifier_mB808E735A25CB3357E33337F9A4B737DDAB6B40F (InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873* __this, const RuntimeMethod* method) 
{
	bool V_0 = false;
	String_t* V_1 = NULL;
	{
		String_t* L_0 = __this->___Identifier;
		bool L_1;
		L_1 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_0, NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		InstallationId_CreateIdentifier_mC089486FCD96983C9186689C41D1D75E36EFB90C(__this, NULL);
	}

IL_0017:
	{
		String_t* L_3 = __this->___Identifier;
		V_1 = L_3;
		goto IL_0020;
	}

IL_0020:
	{
		String_t* L_4 = V_1;
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InstallationId_CreateIdentifier_mC089486FCD96983C9186689C41D1D75E36EFB90C (InstallationId_tA5712B394172DB4DBA3B5F9A67D5522D37E2B873* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	String_t* V_1 = NULL;
	bool V_2 = false;
	bool V_3 = false;
	bool V_4 = false;
	bool V_5 = false;
	bool V_6 = false;
	{
		String_t* L_0;
		L_0 = InstallationId_ReadIdentifierFromFile_m126AF7B4F947DBB382AA8848D51FEA52C91C3E7C(NULL);
		__this->___Identifier = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Identifier), (void*)L_0);
		String_t* L_1 = __this->___Identifier;
		bool L_2;
		L_2 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_1, NULL);
		V_2 = (bool)((((int32_t)L_2) == ((int32_t)0))? 1 : 0);
		bool L_3 = V_2;
		if (!L_3)
		{
			goto IL_0023;
		}
	}
	{
		goto IL_00c6;
	}

IL_0023:
	{
		RuntimeObject* L_4 = __this->___UnityAnalyticsIdentifierProvider;
		NullCheck(L_4);
		String_t* L_5;
		L_5 = InterfaceFuncInvoker0< String_t* >::Invoke(0, IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var, L_4);
		V_0 = L_5;
		RuntimeObject* L_6 = __this->___UnityAdsIdentifierProvider;
		NullCheck(L_6);
		String_t* L_7;
		L_7 = InterfaceFuncInvoker0< String_t* >::Invoke(0, IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var, L_6);
		V_1 = L_7;
		String_t* L_8 = V_0;
		bool L_9;
		L_9 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_8, NULL);
		V_3 = (bool)((((int32_t)L_9) == ((int32_t)0))? 1 : 0);
		bool L_10 = V_3;
		if (!L_10)
		{
			goto IL_0053;
		}
	}
	{
		String_t* L_11 = V_0;
		__this->___Identifier = L_11;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Identifier), (void*)L_11);
		goto IL_007a;
	}

IL_0053:
	{
		String_t* L_12 = V_1;
		bool L_13;
		L_13 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_12, NULL);
		V_4 = (bool)((((int32_t)L_13) == ((int32_t)0))? 1 : 0);
		bool L_14 = V_4;
		if (!L_14)
		{
			goto IL_006d;
		}
	}
	{
		String_t* L_15 = V_1;
		__this->___Identifier = L_15;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Identifier), (void*)L_15);
		goto IL_007a;
	}

IL_006d:
	{
		String_t* L_16;
		L_16 = InstallationId_GenerateGuid_m7220D8C5AE5B4DCA4F4C01A6F921FF66C23E855A(NULL);
		__this->___Identifier = L_16;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___Identifier), (void*)L_16);
	}

IL_007a:
	{
		String_t* L_17 = __this->___Identifier;
		InstallationId_WriteIdentifierToFile_m67273AD8773FDBEE468B0BB7F502B3383AB9A6C4(L_17, NULL);
		String_t* L_18 = V_0;
		bool L_19;
		L_19 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_18, NULL);
		V_5 = L_19;
		bool L_20 = V_5;
		if (!L_20)
		{
			goto IL_00a6;
		}
	}
	{
		RuntimeObject* L_21 = __this->___UnityAnalyticsIdentifierProvider;
		String_t* L_22 = __this->___Identifier;
		NullCheck(L_21);
		InterfaceActionInvoker1< String_t* >::Invoke(1, IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var, L_21, L_22);
	}

IL_00a6:
	{
		String_t* L_23 = V_1;
		bool L_24;
		L_24 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_23, NULL);
		V_6 = L_24;
		bool L_25 = V_6;
		if (!L_25)
		{
			goto IL_00c6;
		}
	}
	{
		RuntimeObject* L_26 = __this->___UnityAdsIdentifierProvider;
		String_t* L_27 = __this->___Identifier;
		NullCheck(L_26);
		InterfaceActionInvoker1< String_t* >::Invoke(1, IUserIdentifierProvider_t37955FEADD673B2F4333F6D756F9F9BEC3486E41_il2cpp_TypeInfo_var, L_26, L_27);
	}

IL_00c6:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* InstallationId_ReadIdentifierFromFile_m126AF7B4F947DBB382AA8848D51FEA52C91C3E7C (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9802A0C242B6B1F11EC74461BB2DF09CE62B8035);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		String_t* L_0;
		L_0 = PlayerPrefs_GetString_mA4C9F842BF77E5572AB20EA087C7048F870D02AE(_stringLiteral9802A0C242B6B1F11EC74461BB2DF09CE62B8035, NULL);
		V_0 = L_0;
		goto IL_000e;
	}

IL_000e:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InstallationId_WriteIdentifierToFile_m67273AD8773FDBEE468B0BB7F502B3383AB9A6C4 (String_t* ___0_identifier, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9802A0C242B6B1F11EC74461BB2DF09CE62B8035);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_identifier;
		PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256(_stringLiteral9802A0C242B6B1F11EC74461BB2DF09CE62B8035, L_0, NULL);
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* InstallationId_GenerateGuid_m7220D8C5AE5B4DCA4F4C01A6F921FF66C23E855A (const RuntimeMethod* method) 
{
	Guid_t V_0;
	memset((&V_0), 0, sizeof(V_0));
	String_t* V_1 = NULL;
	{
		Guid_t L_0;
		L_0 = Guid_NewGuid_m1F4894E8DC089811D6252148AD5858E58D43A7BD(NULL);
		V_0 = L_0;
		String_t* L_1;
		L_1 = Guid_ToString_m2BFFD5FA726E03FA707AAFCCF065896C46D5290C((&V_0), NULL);
		V_1 = L_1;
		goto IL_0017;
	}

IL_0017:
	{
		String_t* L_2 = V_1;
		return L_2;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NSUserDefaults_GetString_mA77E63188B222653CB1C8AA0B0CB089F7EE0690E (String_t* ___0_key, const RuntimeMethod* method) 
{
	bool V_0 = false;
	String_t* V_1 = NULL;
	{
		String_t* L_0 = ___0_key;
		bool L_1;
		L_1 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_0, NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_3 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE7D028CCE3B6E7B61AE2C752D7AE970DA04AB7C6)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NSUserDefaults_GetString_mA77E63188B222653CB1C8AA0B0CB089F7EE0690E_RuntimeMethod_var)));
	}

IL_0017:
	{
		String_t* L_4 = ___0_key;
		String_t* L_5;
		L_5 = NSUserDefaults_UserDefaultsGetString_m92C7603D4E38B141A88AC3E2B87B1DF1600A06A8(L_4, NULL);
		V_1 = L_5;
		goto IL_0020;
	}

IL_0020:
	{
		String_t* L_6 = V_1;
		return L_6;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NSUserDefaults_SetString_m0BFB3A66E345CE80C080620675028FDE686166F0 (String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method) 
{
	bool V_0 = false;
	{
		String_t* L_0 = ___0_key;
		bool L_1;
		L_1 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_0, NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0017;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_3 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE7D028CCE3B6E7B61AE2C752D7AE970DA04AB7C6)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NSUserDefaults_SetString_m0BFB3A66E345CE80C080620675028FDE686166F0_RuntimeMethod_var)));
	}

IL_0017:
	{
		String_t* L_4 = ___0_key;
		String_t* L_5 = ___1_value;
		NSUserDefaults_UserDefaultsSetString_m6D339E36904A6238646E398703ED1CB13D09BA83(L_4, L_5, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NSUserDefaults_UserDefaultsGetString_m92C7603D4E38B141A88AC3E2B87B1DF1600A06A8 (String_t* ___0_key, const RuntimeMethod* method) 
{
	typedef char* (DEFAULT_CALL *PInvokeFunc) (char*);

	char* ____0_key_marshaled = NULL;
	____0_key_marshaled = il2cpp_codegen_marshal_string(___0_key);

	char* returnValue = reinterpret_cast<PInvokeFunc>(UOCPUserDefaultsGetString)(____0_key_marshaled);

	String_t* _returnValue_unmarshaled = NULL;
	_returnValue_unmarshaled = il2cpp_codegen_marshal_string_result(returnValue);

	il2cpp_codegen_marshal_free(returnValue);
	returnValue = NULL;

	il2cpp_codegen_marshal_free(____0_key_marshaled);
	____0_key_marshaled = NULL;

	return _returnValue_unmarshaled;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NSUserDefaults_UserDefaultsSetString_m6D339E36904A6238646E398703ED1CB13D09BA83 (String_t* ___0_key, String_t* ___1_value, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	char* ____0_key_marshaled = NULL;
	____0_key_marshaled = il2cpp_codegen_marshal_string(___0_key);

	char* ____1_value_marshaled = NULL;
	____1_value_marshaled = il2cpp_codegen_marshal_string(___1_value);

	reinterpret_cast<PInvokeFunc>(UOCPUserDefaultsSetString)(____0_key_marshaled, ____1_value_marshaled);

	il2cpp_codegen_marshal_free(____0_key_marshaled);
	____0_key_marshaled = NULL;

	il2cpp_codegen_marshal_free(____1_value_marshaled);
	____1_value_marshaled = NULL;

}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UnityAdsIdentifier_get_UserId_m4E41B6AEB6405B6BFA7D4E52FE3F66478A18D90A (UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56* __this, const RuntimeMethod* method) 
{
	String_t* V_0 = NULL;
	{
		String_t* L_0;
		L_0 = UnityAdsIdentifier_get_IdentifierForInstallIos_m510AD72EA3847591D1F1AE3214FE4E81A258092E(NULL);
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		String_t* L_1 = V_0;
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAdsIdentifier_set_UserId_mA2519CC19694D24C35D6E2E72B79E2CE34DACA4F (UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56* __this, String_t* ___0_value, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_value;
		UnityAdsIdentifier_set_IdentifierForInstallIos_mD9D71B7910AA0380D1C5E9445A04B6E812C5F835(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UnityAdsIdentifier_get_IdentifierForInstallIos_m510AD72EA3847591D1F1AE3214FE4E81A258092E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralECBE14D0ACE36FACE92343327DF7DFEC932523A5);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0;
		L_0 = NSUserDefaults_GetString_mA77E63188B222653CB1C8AA0B0CB089F7EE0690E(_stringLiteralECBE14D0ACE36FACE92343327DF7DFEC932523A5, NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAdsIdentifier_set_IdentifierForInstallIos_mD9D71B7910AA0380D1C5E9445A04B6E812C5F835 (String_t* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralECBE14D0ACE36FACE92343327DF7DFEC932523A5);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_value;
		NSUserDefaults_SetString_m0BFB3A66E345CE80C080620675028FDE686166F0(_stringLiteralECBE14D0ACE36FACE92343327DF7DFEC932523A5, L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAdsIdentifier__ctor_mFD5085EB0AD902D689B820D13D697CE640E2E7B8 (UnityAdsIdentifier_t8D3A8D6DB9A1FB469E2E7F3D58B30C3D0D71DA56* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UnityAnalyticsIdentifier_get_UserId_m15964ABDB88E2D752C471143ED9C5A32017989CE (UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral20353326ACF03BB4112F3080DBCA0AC47DBC7BB2);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0;
		L_0 = PlayerPrefs_GetString_mA4C9F842BF77E5572AB20EA087C7048F870D02AE(_stringLiteral20353326ACF03BB4112F3080DBCA0AC47DBC7BB2, NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAnalyticsIdentifier_set_UserId_m2751FA3CB0A777DAC8AA56ECBE8945EED55CAC3C (UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D* __this, String_t* ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral20353326ACF03BB4112F3080DBCA0AC47DBC7BB2);
		s_Il2CppMethodInitialized = true;
	}
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
	}
	try
	{
		String_t* L_0 = ___0_value;
		PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256(_stringLiteral20353326ACF03BB4112F3080DBCA0AC47DBC7BB2, L_0, NULL);
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		goto IL_001c;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0017;
		}
		throw e;
	}

CATCH_0017:
	{
		Exception_t* L_1 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_001c;
	}

IL_001c:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UnityAnalyticsIdentifier__ctor_mE19B73CB1414B5AC0619E8EF1366C0164B06D14B (UnityAnalyticsIdentifier_tAB8DD85C666D878FC108C324E10DF6528B5BDA5D* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
