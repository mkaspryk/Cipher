#pragma once
#include <iostream>
#include <algorithm>
#include <string>

class Caesar
{
	/**
	* Field orginalSentence represents orginal sentence passed to encrypt or decrypt
	*/
	std::string orginalSentence; 
	/**
	* Field encryptedSentence represents enrypted sentence
	*/
	std::string encryptedSentence;
	/**
	* Field decryptedSentence represents decrypted sentence
	*/
	std::string decryptedSentence;
	/**
	* Field key represents shift in Caesar Cipher
	*/
	int key;

public:

	//--------------------------------------------------------

	/**
	* No-Arg Constructor
	*/
	Caesar();
	/**
	* Main constructor which is used in program
	* sentence1 - orginal sentence passed to program
	* key1 - shift
	*/
	Caesar(std::string sentence1, int key1);
	/**
	* Destructor
	*/
	~Caesar();

	//--------------------------------------------------------

	/**
	* Set the key
	*/
	void setKey(int key1);
	/**
	* Get the key
	*/
	int getKey();

	//--------------------------------------------------------

	/**
	* Set the orginal sentence
	*/
	void setOrginalSentence(std::string sentence1);
	/**
	* Get the orginal sentence
	*/
	std::string getOrginalSentence();

	//--------------------------------------------------------

	/**
	* Set the encrypted sentence
	*/
	void setEncryptedSentence(std::string sentence1);
	/**
	* Get the encrypted sentence
	*/
	std::string getEncryptedSentence();

	//--------------------------------------------------------

	/**
	* Set the decrypted sentence
	*/
	void setDecryptedSentence(std::string sentence1);
	/**
	* Get the decrypted sentence
	*/
	std::string getDecryptedSentence();

	//--------------------------------------------------------

	/**
	* Encrypt orginal sentence to encrypted sentence
	*/
	void encrypt();
	/**
	* Decrypt orginal sentence to decrypted sentence
	*/
	void decrypt();
	/**
	* check the sign
	* return 1 - if sign is correct from 'A' to 'Z'
	* return 0 - if is incorrect
	*/
	int checkSign(char znak);

	//--------------------------------------------------------
};

