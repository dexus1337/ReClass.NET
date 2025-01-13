#include <windows.h>

#include "NativeCore.hpp"
#include "ServerRemoteTool.h"

int WriteMemoryWindows(RC_Pointer handle, RC_Pointer address, RC_Pointer buffer, int size)
{
    SIZE_T numberOfBytesWritten;
	DWORD oldProtect;
	if (VirtualProtectEx(handle, address, size, PAGE_EXECUTE_READWRITE, &oldProtect))
	{
		if (WriteProcessMemory(handle, address, buffer, size, &numberOfBytesWritten))
		{
			VirtualProtectEx(handle, address, size, oldProtect, nullptr);
		}
	}

	return numberOfBytesWritten;
}

bool RC_CallConv WriteRemoteMemory(RC_Pointer handle, RC_Pointer address, RC_Pointer buffer, int offset, int size)
{
	if (g_IsDumpAnalysis)
	{
		return false;
	}

	buffer = reinterpret_cast<RC_Pointer>(reinterpret_cast<uintptr_t>(buffer) + offset);

	int numberOfBytesWritten;
	if (ServerManager::getInstance()->PartiallyConnected()) numberOfBytesWritten = WriteMemoryServer(handle, address, buffer, size);
	else numberOfBytesWritten = WriteMemoryWindows(handle, address, buffer, size);

	return size == numberOfBytesWritten;
}