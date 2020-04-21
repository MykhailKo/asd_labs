#include "MyString.h"


MyString::MyString() {
	_string = new char[0];
}

MyString::MyString(char * str){
	_string = str;
}

MyString::~MyString() {
	_string = nullptr;
	delete _string;
}


