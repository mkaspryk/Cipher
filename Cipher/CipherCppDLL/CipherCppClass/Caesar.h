#pragma once
#include <iostream>
#include <algorithm>
#include <string>

class Caesar
{
	std::string orginalSentence; 
	std::string encryptedSentence;
	std::string decryptedSentence;
	int key;
public:
	//--------------------------------------------------------

	Caesar();

	Caesar(std::string sentence1, int key1);

	~Caesar();

	//--------------------------------------------------------

	void setKey(int key1);

	int getKey();

	//--------------------------------------------------------

	void setOrginalSentence(std::string sentence1);

	std::string getOrginalSentence();

	//--------------------------------------------------------

	void setEncryptedSentence(std::string sentence1);

	std::string getEncryptedSentence();

	//--------------------------------------------------------

	void setDecryptedSentence(std::string sentence1);

	std::string getDecryptedSentence();

	//--------------------------------------------------------
	void encrypt();

	void decrypt();

	int checkSign(char znak);

	std::string toUpper(std::string s);

	//--------------------------------------------------------
};

