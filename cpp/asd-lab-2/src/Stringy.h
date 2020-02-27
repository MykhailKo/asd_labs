#ifndef STRINGY_H_
#define STRINGY_H_

class Stringy {
private:
	char* _symbols = nullptr;
public:
	Stringy(char*);
	virtual ~Stringy();
	int getLength();
	int getDigits();
	char* getSymbols();
};

#endif /* STRINGY_H_ */
