#pragma once

#include "../ReClassNET_Plugin.hpp"
#include "../Shared/Keys.hpp"
#include <windows.h>

extern HANDLE g_hCdbProcess;
extern HANDLE g_hChildStd_IN_Wr;
extern HANDLE g_hChildStd_OUT_Rd;
extern HANDLE g_hChildStd_ERR_Rd;
extern bool g_IsDumpAnalysis;

void RC_CallConv EnumerateProcesses(EnumerateProcessCallback callbackProcess);
void RC_CallConv EnumerateRemoteSectionsAndModules(RC_Pointer handle, EnumerateRemoteSectionsCallback callbackSection, EnumerateRemoteModulesCallback callbackModule);

RC_Pointer RC_CallConv OpenRemoteProcess(RC_Pointer id, ProcessAccess desiredAccess);
bool RC_CallConv IsProcessValid(RC_Pointer handle);
void RC_CallConv CloseRemoteProcess(RC_Pointer handle);

bool RC_CallConv ReadRemoteMemory(RC_Pointer handle, RC_Pointer address, RC_Pointer buffer, int offset, int size);
bool RC_CallConv WriteRemoteMemory(RC_Pointer handle, RC_Pointer address, RC_Pointer buffer, int offset, int size);

void RC_CallConv ControlRemoteProcess(RC_Pointer handle, ControlRemoteProcessAction action);

bool RC_CallConv AttachDebuggerToProcess(RC_Pointer id);
void RC_CallConv DetachDebuggerFromProcess(RC_Pointer id);
bool RC_CallConv AwaitDebugEvent(DebugEvent* evt, int timeoutInMilliseconds);
void RC_CallConv HandleDebugEvent(DebugEvent* evt);
bool RC_CallConv SetHardwareBreakpoint(RC_Pointer id, RC_Pointer address, HardwareBreakpointRegister reg, HardwareBreakpointTrigger type, HardwareBreakpointSize size, bool set);

RC_Pointer RC_CallConv InitializeInput();
bool RC_CallConv GetPressedKeys(RC_Pointer handle, Keys* state[], int* count);
void RC_CallConv ReleaseInput(RC_Pointer handle);

int32_t RC_CallConv ConnectServer(const char* pIpStr, short port);
void RC_CallConv DisconnectServer();

bool RC_CallConv OpenDumpFile(RC_Pointer dumpFilePath);