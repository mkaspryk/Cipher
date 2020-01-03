// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the CIPHERASMDLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// CIPHERASMDLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CIPHERASMDLL_EXPORTS
#define CIPHERASMDLL_API __declspec(dllexport)
#else
#define CIPHERASMDLL_API __declspec(dllimport)
#endif

// This class is exported from the dll
class CIPHERASMDLL_API CCipherAsmDLL {
public:
	CCipherAsmDLL(void);
	// TODO: add your methods here.
};

extern CIPHERASMDLL_API int nCipherAsmDLL;

CIPHERASMDLL_API int fnCipherAsmDLL(void);
