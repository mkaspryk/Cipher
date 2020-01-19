#include "CaesarSIMD.h"
#include <dvec.h>
#include <immintrin.h>

void encryptCaesar(char orginalSentence[], int key, int size) {

	__m128i _k = _mm_loadu_si64(&key);                                             // load unaligned 64-bit integer key from memory into the 128-bit register
	__m128i _mask = _mm_broadcastb_epi8(_k);                                       // broadcast the low packed 8-bit integer from _k(one byte) to all elements of _mask (128-bit register)
	int wsk_size = 0;
	while (wsk_size < size) {
		__m128i _oS = _mm_loadu_si64((const __m128i*)&orginalSentence[wsk_size]);  // load unaligned 64-bit integer table orginalSentence from memory into the 128-bit register
		__m128i _rS = _mm_add_epi8(_mask, _oS);                                    // add two 128-bit registers _mask and _oS and load into _rS
		_mm_storeu_si64(&orginalSentence[wsk_size], _rS);                          // store 64-bit integer from the first element of _rS into memory of orginalSentence
		for (int i = wsk_size; i < (wsk_size + 8); i++) {                          // for loop to check the sign in orginalSentence table
			if (orginalSentence[i] > 'Z')
			{
				int tmp = orginalSentence[i] - 'Z' - 1;
				orginalSentence[i] = 'A' + tmp;
			}
		}
		wsk_size += 8;                                                             // increment wsk_size(ptr) to the next 8 bytes
	}
}

void decryptCaesar(char orginalSentence[], int key, int size) {

	key = -key;
	__m128i _k = _mm_loadu_si64(&key);                                             // load unaligned 64-bit integer key from memory into the 128-bit register
	__m128i _mask = _mm_broadcastb_epi8(_k);                                       // broadcast the low packed 8-bit integer from _k(one byte) to all elements of _mask (128-bit register)
	int wsk_size = 0;
	while (wsk_size < size) {
		__m128i _oS = _mm_loadu_si64((const __m128i*)&orginalSentence[wsk_size]);  // load unaligned 64-bit integer table orginalSentence from memory into the 128-bit register
		__m128i _rS = _mm_add_epi8(_mask, _oS);                                    // add two 128-bit registers _mask and _oS and load into _rS
		_mm_storeu_si64(&orginalSentence[wsk_size], _rS);                          // store 64-bit integer from the first element of _rS into memory of orginalSentence
		for (int i = wsk_size; i < (wsk_size + 8); i++) {                          // for loop to check the sign in orginalSentence table
			if (orginalSentence[i] < 'A')
			{
				int tmp = 'A' - orginalSentence[i] - 1;
				orginalSentence[i] = 'Z' - tmp;
				if (orginalSentence[i] == ':')
					orginalSentence[i] = ' ';
			}
		}
		wsk_size += 8;                                                             // increment wsk_size(ptr) to the next 8 bytes
	}
}