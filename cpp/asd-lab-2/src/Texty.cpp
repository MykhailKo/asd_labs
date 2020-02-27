#include "Stringy.h"
#include "Texty.h"
#include <iostream>


Texty::Texty(Stringy* s, int si) {
	_size = si;
	_strings = s;
	for(int i = 0; i < _size; i++){
		_length += _strings[i].getLength();
		_digits += _strings[i].getDigits();
	}
}

Texty::~Texty() {
	_strings = nullptr;
	delete[] _strings;
	_size = 0;
}

char* Texty::getLongestString(){
	int longest = 0;
	for(int i = 0; i < _size; i++){
		if(_strings[i].getLength() > _strings[longest].getLength()) longest = i;
	}
	return _strings[longest].getSymbols();
}

bool Texty::deleteString(int index){
	if(index > _size - 1){
		return 0;
	}else{
		for(int i = index; i < _size; i++){
			_strings[i] = _strings[i + 1];
		}
		_size -= 1;
		return 1;
	}
}

int Texty::getLength(){
	return _length;
}
int Texty::getSize(){
	return _size;
}
double Texty::getDigitsPercentage(){
	return _digits * 100 / _length;
}
Stringy* Texty::getStrings(){
	return _strings;
}


