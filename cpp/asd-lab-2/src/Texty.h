#ifndef TEXTY_H_
#define TEXTY_H_
#include <iostream>
#include "Stringy.h"

class Texty {
public:
	Stringy* strings = nullptr;
	int size = 0;
	int digits = 0;
	int length = 0;
	Texty(Stringy*, int);
	virtual ~Texty();
	bool deleteString(int);
	char* getLongestString();
	int getLength();
	double getDigitsPercentage();
};


#endif /* TEXTY_H_ */
