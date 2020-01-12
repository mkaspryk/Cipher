#include "Vigenere.h"

//--------------------------------------------------------

Vigenere::Vigenere() {}

Vigenere::Vigenere(std::string sentence1, std::string keyword1):orginalSentence(sentence1), keyword(toUpper(keyword1)) {}

Vigenere::~Vigenere() {}

//--------------------------------------------------------

void Vigenere::setOrginalSentence(std::string sentence1) {orginalSentence = sentence1;}

std::string Vigenere::getOrginalSentence() {return orginalSentence;}

//--------------------------------------------------------

void Vigenere::setEncryptedSentence(std::string sentence1) {encryptedSentence = sentence1;}

std::string Vigenere::getEncryptedSentence() {return encryptedSentence;}

//--------------------------------------------------------

void Vigenere::setDecryptedSentence(std::string sentence1) { decryptedSentence = sentence1; }

std::string Vigenere::getDecryptedSentence() {return decryptedSentence;}

//--------------------------------------------------------

void Vigenere::setKeyword(std::string keyword1) {keyword = keyword1;}

std::string Vigenere::getKeyword() {return keyword;}

//--------------------------------------------------------

void Vigenere::encrypt() {

	unsigned int iterKey = 0;
	encryptedSentence = orginalSentence;
	for (unsigned int i = 0; i < encryptedSentence.length(); i++) {

		if (isalpha(encryptedSentence[i])) {
			encryptedSentence[i] += keyword[iterKey] - 'A';
			if (encryptedSentence[i] > 'Z')
				encryptedSentence[i] += 'A' - 'Z' - 1;
		}
		if ((iterKey + 1) == keyword.length()) 
			iterKey = 0;
		else 
			iterKey = iterKey + 1;
	}
}

void Vigenere::decrypt(){

	unsigned int iterKey = 0;
	decryptedSentence = orginalSentence;
	for (unsigned int i = 0; i < decryptedSentence.length(); i++) {

		if (isalpha(decryptedSentence[i])) {
			if (decryptedSentence[i] >= keyword[iterKey])
				decryptedSentence[i] = decryptedSentence[i] - keyword[iterKey] + 'A';
			else 
				decryptedSentence[i] = 'A' + ('Z' - keyword[iterKey] + decryptedSentence[i] - 'A') + 1;
		}
		if ((iterKey + 1) == keyword.length())
			iterKey = 0;
		else
			iterKey = iterKey + 1;
	}
}

std::string Vigenere::toUpper(std::string s) {
	std::transform(s.begin(), s.end(), s.begin(), ::toupper);
	return s;
}

//--------------------------------------------------------