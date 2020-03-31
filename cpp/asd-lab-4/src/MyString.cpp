#include "MyString.h"
#include <string.h>
#include <ctype.h>

MyString::MyString(char * str){
	_string = str;
}

MyString::MyString() {
	_string = new char[0];
}

MyString::MyString(MyString &other) {
	_string = (char*)other._string;
}

MyString::~MyString() {
	_string = nullptr;
	delete _string;
}

int MyString::getLength(){
	return strlen(_string);
}

string MyString::getValue(){
	return _string;
}

MyString MyString::operator +(MyString str){
	MyString result;
	result._string = new char[getLength() + str.getLength()];
	for (int i = 0; i < getLength() + str.getLength(); i++){
		result._string[i] = i < getLength() ? _string[i] : str._string[i-getLength()];
	}

	return result;
}

MyString MyString::operator -(char subst){
	MyString result;
	result._string = new char[getLength() - 1];
	int substIndex = 0;
	while (_string[substIndex] != subst) substIndex++;
	for (int i = 0; i < getLength() - 1; i++)
		result._string[i] = i < substIndex ? _string[i] : _string[i + 1];

	return result;
}

