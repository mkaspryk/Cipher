#include "VigenereSIMD.h"
#include <dvec.h>
#include <immintrin.h>

void encryptVigenere(char orginalSentence[], char keyword[], int size) {

	int wsk_size = 0;
	int numA = 65;                                                                    // A letter
	__m128i _numA = _mm_loadu_si64((const __m128i*)&numA);                            // load unaligned 64-bit integer numA from memory into the 128-bit register _numA
	__m128i _mask65 = _mm_broadcastb_epi8(_numA);                                     // broadcast the low packed 8-bit integer from _numA(one byte) to all elements of _mask65 (128-bit register)
	while (wsk_size < size) {
		__m128i _oS = _mm_loadu_si64((const __m128i*)&orginalSentence[wsk_size]);     // load unaligned 64-bit integer table orginalSentence from memory into the 128-bit register _oS
		__m128i _kW = _mm_loadu_si64((const __m128i*)&keyword[wsk_size]);             // load unaligned 64-bit integer table keyword from memory into the 128-bit register _kW
		__m128i _sub = _mm_sub_epi8(_kW, _mask65);                                    // subtract packed 8 - bit integers in _mask65 from packed 8 - bit integers in _kW, and store the results in _sub
		__m128i _rS = _mm_add_epi8(_oS, _sub);                                        // add two 128-bit registers _oS and _sub and store in _rS
		_mm_storeu_si64(&orginalSentence[wsk_size], _rS);                             // store 64-bit integer from the first element of _rS into memory of orginalSentence
		for (int i = wsk_size; i < (wsk_size + 8); i++) {                             // for loop to check the sign in orginalSentence table
			if (orginalSentence[i] > 'Z')
				orginalSentence[i] += 'A' - 'Z' - 1;
		}
		wsk_size += 8;                                                                // increment wsk_size(ptr) to the next 8 bytes
	}
}

void decryptVigenere(char orginalSentence[], char keyword[], int size) {

	int wsk_size = 0;
	int numA = 65;                                                                    // A letter
	__m128i _numA = _mm_loadu_si64((const __m128i*)&numA);                            // load unaligned 64-bit integer numA from memory into the 128-bit register _numA
	__m128i _mask65 = _mm_broadcastb_epi8(_numA);                                     // broadcast the low packed 8-bit integer from _numA(one byte) to all elements of _mask65 (128-bit register)
	while (wsk_size < size) {
		__m128i _oS = _mm_loadu_si64((const __m128i*)&orginalSentence[wsk_size]);     // load unaligned 64-bit integer table orginalSentence from memory into the 128-bit register _oS
		__m128i _kW = _mm_loadu_si64((const __m128i*)&keyword[wsk_size]);             // load unaligned 64-bit integer table keyword from memory into the 128-bit register _kW
		__m128i _sub = _mm_sub_epi8(_mask65, _kW);                                    // subtract packed 8 - bit integers in _kW from packed 8 - bit integers in _mask65, and store the results in _sub
		__m128i _rS = _mm_add_epi8(_oS, _sub);                                        // add two 128-bit registers _oS and _sub and store in _rS
		_mm_storeu_si64(&orginalSentence[wsk_size], _rS);                             // store 64-bit integer from the first element of _rS into memory of orginalSentence
		for (int i = wsk_size; i < (wsk_size + 8); i++) {                             // for loop to check the sign in orginalSentence table
			if (orginalSentence[i] < 'A') {
				orginalSentence[i] += 'Z' - 'A' + 1;
				if (orginalSentence[i] == ':') 
					orginalSentence[i] = ' ';
			}
		}
		wsk_size += 8;                                                                // increment wsk_size(ptr) to the next 8 bytes
	}
}
