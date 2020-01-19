#include <iostream>

using namespace std;

extern "C" int someFunction();
extern "C" void encryptCaesarAsm(char sentence[],int key,int size);
extern "C" void decryptCaesarAsm(char sentence[], int key, int size);
extern "C" void encryptVigenereAsm(char sentence[], char keyword[], long long int sizeSentence, long long int sizeKeyword);
extern "C" void testAVX(char sentence[],int key);
extern "C" void caesar(char sentence[], char keyword[], int size);

extern "C" void vigenereasm(char sentence[], char keyword[], long long int sizeSentence, long long int sizeKeyword);

int main() {

	int key = 2;
	char sentence[] = "AAAAAAAAA";
	int sizeSentence = 2;
	char keyword[] = "BBBBBBBBB";
	int sizeKeyword = 15;

	caesar(sentence, keyword, 9);

	//vigenereasm(sentence, keyword, sizeSentence, sizeKeyword);
	//caesar(sentence, key, sizeSentence);
	//encryptCaesarAsm(sentence, key, sizeSentence);
    //cout << sentence << endl;
	//testAVX(sentence,key);
	//encryptVigenereAsm(sentence, keyword, sizeSentence, sizeKeyword);
	cout << sentence << endl;
	/*encryptCaesarAsm(sentence, key, size);
	cout << sentence << endl;
	decryptCaesarAsm(sentence, key, size);*/
	//cout << sentence << endl;
	//cout << "The result is: " << someFunction() << endl;
	return 0;
}

//mov     rax, qword ptr[rbp - 32]
//mov     qword ptr[rbp - 40], rax
//FOR_LOOP :
//mov     rax, qword ptr[rbp - 32]
//add     rax, 7
//cmp     qword ptr[rbp - 40], rax
//jg      TO_WHILE
//mov     rbx, qword ptr[rbp - 40]
//mov     rax, qword ptr[rbp - 8]
//add     rax, rbx
//movzx   eax, byte ptr[rax]
//cmp     al, 64
//jg      INCREMENT_FOR_LOOP
//mov     rbx, qword ptr[rbp - 40]
//mov     rax, qword ptr[rbp - 8]
//add     rax, rbx
//movzx   eax, byte ptr[rax]
//lea     edi, [rax + 26]
//mov     rbx, qword ptr[rbp - 40]
//mov     rax, qword ptr[rbp - 8]
//add     rax, rbx
//mov     ebx, edi
//mov     byte ptr[rax], bl
//mov     rbx, qword ptr[rbp - 40]
//mov     rax, qword ptr[rbp - 8]
//add     rax, rbx
//movzx   eax, byte ptr[rax]
//cmp     al, 58
//jne     INCREMENT_FOR_LOOP
//mov     rbx, qword ptr[rbp - 40]
//mov     rax, qword ptr[rbp - 8]
//add     rax, rbx
//mov     byte ptr[rax], 32
//INCREMENT_FOR_LOOP:
//add     qword ptr[rbp - 40], 1
//jmp     FOR_LOOP
//TO_WHILE :




//mov r14, qword ptr[rbp - 24]
//mov qword ptr[rbp - 32], r14
//FOR_LOOP :
//mov r14, qword ptr[rbp - 24]
//add r14, 7
//cmp qword ptr[rbp - 32], r14
//jg TO_WHILE
//mov r12, qword ptr[rbp - 32]
//mov r14, r15
//add r14, r12
//movzx r13, byte ptr[r14]
//cmp r13, 90
//jle INCREMENT_FOR_LOOP
//mov r12, qword ptr[rbp - 32]
//mov r14, r15
//add r14, r12
//movzx r13, byte ptr[r14]
//mov r11, r13
//sub r11, 91
//add r11, 65
//mov rbx, r11
//add rax, r12
//mov byte ptr[rax], bl
//INCREMENT_FOR_LOOP :
//add qword ptr[rbp - 32], 1
//jmp FOR_LOOP
//TO_WHILE :

//vigenereasm proc
//push    rbp
//mov     rbp, rsp
//mov     rax, rcx
//mov     r11, rdx
//mov     qword ptr[rbp - 8], r8
//mov     qword ptr[rbp - 16], r9
//mov     qword ptr[rbp - 24], 0
//WHILELOOP:
//mov     r13, qword ptr[rbp - 24]
//cmp     r13, qword ptr[rbp - 8]
//jge     ENDFUN
//mov     qword ptr[rbp - 48], qword ptr[rbp - 24]
//mov     r13, rax
//add     r13, qword ptr[rbp - 48]
//mov     r14, r13
//mov     qword ptr[rbp - 48], qword ptr[rbp - 24]
//mov     r13, r11
//add     r13, qword ptr[rbp - 48]
//mov     r15, r13
//movq xmm0, qword ptr[r14]
//movq xmm1, qword ptr[r15]
//mov qword ptr[rbp - 56], 65
//vpbroadcastb xmm3, byte ptr[rbp - 56]
//vpsubb xmm4, xmm1, xmm3
//vpaddb xmm5, xmm0, xmm4
//movq qword ptr[r14], xmm5
//mov     r13, qword ptr[rbp - 24]
//mov     qword ptr[rbp - 40], r13
//FORLOOP :
//mov     r13, qword ptr[rbp - 24]
//add     r13, 7
//cmp     qword ptr[rbp - 40], r13
//jg      INCREMENTSIZE
//mov     qword ptr[rbp - 48], qword ptr[rbp - 40]
//mov     r13, rax
//add     r13, qword ptr[rbp - 48]
//movzx   rbx, byte ptr[r13]
//cmp     rbx, 90
//jle     INCREMENTFORLOOP
//mov     qword ptr[rbp - 48], qword ptr[rbp - 40]
//mov     r13, rax
//add     r13, qword ptr[rbp - 48]
//movzx   rbx, byte ptr[r13]
//lea     ecx, [r13 - 26]
//mov     qword ptr[rbp - 48], qword ptr[rbp - 40]
//mov     r13, rax
//add     r13, qword ptr[rbp - 48]
//mov     edx, ecx
//mov     byte ptr[r13], dl
//INCREMENTFORLOOP :
//add     qword ptr[rbp - 40], 1
//jmp     FORLOOP
//INCREMENTSIZE :
//add     qword ptr[rbp - 24], 8
//jmp     WHILELOOP
//ENDFUN :
//nop
//pop     rbp
//ret
//vigenereasm endp




//mov rax, qword ptr[rbp - 24]
//mov qword ptr[rbp - 32], rax
//FOR_LOOP :
//mov rax, qword ptr[rbp - 24]
//add rax, 7
//cmp qword ptr[rbp - 32], rax
//jg TO_WHILE
//mov rbx, qword ptr[rbp - 32]
//mov rax, qword ptr[rbp - 48]
//add rax, rbx
//movzx eax, byte ptr[rax]
//cmp al, 90
//jle INCREMENT_FOR_LOOP
//mov rbx, qword ptr[rbp - 32]
//mov rax, qword ptr[rbp - 48]
//add rax, rbx
//movzx eax, byte ptr[rax]
//movsx eax, al
//sub eax, 91
//cdqe
//mov qword ptr[rbp - 40], rax
//mov rax, qword ptr[rbp - 40]
//lea edi, [rax + 65]
//mov rbx, qword ptr[rbp - 32]
//mov rax, qword ptr[rbp - 48]
//add rax, rbx
//mov ebx, edi
//mov byte ptr[rax], bl
//INCREMENT_FOR_LOOP :
//add qword ptr[rbp - 32], 1
//jmp FOR_LOOP