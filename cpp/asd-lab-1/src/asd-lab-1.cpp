//============================================================================
// Name        : asd-lab-1.cpp
// Author      : Kosiuk Mykhailo
// Version     :
// Copyright   : Your copyright notice
// Description : Hello World in C++, Ansi-style
//============================================================================

#include <iostream>
using namespace std;

int increment(int);
void increment(int, int &i);
bool isequal(int, int);
void isequal(int, int, bool &b);
int main() {
	int n1 = 32, n2 = 33;

	bool is_equal = isequal(n1, n2);
	cout << is_equal << endl;

	bool res = 0;
	isequal(n1, n2, res);
	cout << res << endl;

	int n = -43;

	int res_i = increment(n);
	cout << res_i << endl;

	int res_i_2;
	increment(n, res_i_2);
	cout << res_i_2;

}

int increment(int a){
	int size = sizeof(a)*8;
	for(int shift = 0; shift < (size - 1); shift++){
		a ^= 1 << shift;
		if(!(!((a >> shift) & 1) ^ 0)) break;
	}
	return a;
}

void increment(int a, int &res){
	int size = sizeof(a)*8;
	for(int shift = 0; shift < (size - 1); shift++){
		a ^= 1 << shift;
		if(!(!((a >> shift) & 1) ^ 0)) break;
	}
	res = a;
}

bool isequal(int a, int b){
	int size = sizeof(a)*8;
	for(int shift = size - 1; shift >= 0; shift--){
		if(((a >> shift) & 1) ^ ((b >> shift) & 1)) return 0;
	}
	return 1;
}

void isequal(int a, int b, bool &res){
	int size = sizeof(a)*8;
	res = 1;
	for(int shift = size - 1; shift >= 0; shift--){
		if(((a >> shift) & 1) ^ ((b >> shift) & 1)){
			res = 0;
			break;
		};
	}
}

