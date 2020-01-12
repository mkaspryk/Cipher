.code
;Caesar Ciphery
encryptCaesarAsm proc
push rbp
mov rbp,rsp
mov rax,rcx 
mov qword ptr[rbp-8],rdx
mov qword ptr[rbp-16],r8
mov qword ptr[rbp-24],0
vpbroadcastb xmm2,byte ptr[rbp-8]
WHILELOOP:
mov rbx, qword ptr[rbp-24]
cmp rbx, qword ptr[rbp-16]
jge ENDFUN
mov r8,qword ptr[rbp-24]
mov rbx, rax
add rbx,r8
mov r15,rbx
vpaddb xmm0, xmm2,byte ptr[r15]
movq qword ptr[r15],xmm0
add qword ptr[rbp-24],8
jmp WHILELOOP
ENDFUN:
nop
pop rbp
ret
encryptCaesarAsm endp


decryptCaesarAsm proc
push rbp
mov rbp,rsp
mov rax,rcx 
mov qword ptr[rbp-8],rdx
mov qword ptr[rbp-16],r8
mov qword ptr[rbp-24],0
neg qword ptr[rbp-8]
vpbroadcastb xmm2,byte ptr[rbp-8]
WHILESEC:
mov rbx, qword ptr[rbp-24]
cmp rbx, qword ptr[rbp-16]
jge ENDFUN
mov r8,qword ptr[rbp-24]
mov rbx, rax
add rbx,r8
mov r15,rbx
vpaddb xmm0, xmm2,byte ptr[r15]
movq qword ptr[r15],xmm0
add qword ptr[rbp-24],8
jmp WHILESEC
ENDFUN:
nop
pop rbp
ret
decryptCaesarAsm endp

;Vigenere Cipher
encryptVigenereAsm proc

encryptVigenereAsm endp

decryptVigenereAsm proc

decryptVigenereAsm endp

enCaesarAsm proc
push rbp
mov rbp,rsp
mov qword ptr[rbp-24],rcx 
mov qword ptr[rbp-32], rdx
mov qword ptr[rbp-40], r8
mov qword ptr[rbp-8], 0
FORLOOP:
mov rax,qword ptr[rbp-8]
cmp rax,qword ptr[rbp-40]
jge ENDFUN
mov rdx,qword ptr[rbp-8]
mov rax,qword ptr[rbp-24]
add rax, rdx
movzx   eax, byte ptr[rax]
cmp al, 64
jle INCREMENTLOOP
mov rdx,qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 90
jg INCREMENTLOOP
mov byte ptr[rbp-9], 65
mov byte ptr[rbp-10], 90
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
movsx rdx, al
mov rax, qword ptr[rbp-32]
add rdx, rax
movsx rax, byte ptr[rbp-10]
cmp rdx, rax
jg ELSELOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-32]
lea ecx, [rdx+rax]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
jmp INCREMENTLOOP
ELSELOOP:
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-32]
add eax, edx
lea ecx, [rax-26]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
INCREMENTLOOP:
add qword ptr[rbp-8], 1
jmp FORLOOP
ENDFUN:
nop
pop rbp
ret
enCaesarAsm endp

deCaesarAsm proc
push rbp
mov rbp, rsp
mov qword ptr[rbp-40], rcx 
mov qword ptr[rbp-48], rdx
mov qword ptr[rbp-56], r8
mov eax, 26
sub rax, qword ptr[rbp-48]
mov qword ptr[rbp-16], rax
mov qword ptr[rbp-8], 0
FORLOOP:
mov rax, qword ptr[rbp-8]
cmp rax, qword ptr[rbp-56]
jge ENDFUN
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 64
jle INCREMENTLOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 90
jg INCREMENTLOOP
mov byte ptr[rbp-17], 65
mov byte ptr[rbp-18], 90
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
movsx rdx, al
mov rax, qword ptr[rbp-16]
add rdx, rax
movsx rax, byte ptr[rbp-18]
cmp rdx, rax
jg ELSELOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-16]
lea ecx, [rdx+rax]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
jmp INCREMENTLOOP
ELSELOOP:
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-16]
add eax, edx
lea ecx, [rax-26]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
INCREMENTLOOP:
add qword ptr[rbp-8], 1
jmp FORLOOP
ENDFUN:
nop
pop rbp
ret
deCaesarAsm endp

;Vigenere Cipher
enVigenereAsm proc
push rbp
mov rbp, rsp
mov qword ptr [rbp-24], rcx
mov qword ptr [rbp-32], rdx
mov qword ptr [rbp-40], r8
mov qword ptr [rbp-48], r9
mov qword ptr [rbp-8], 0
mov dword ptr [rbp-12], 0
FORLOOP:
mov eax, dword ptr [rbp-12]
cmp qword ptr [rbp-40], rax
jle ENDFUN
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 64
jle IFEQUALITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90
jg IFEQUALITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
add eax, ecx
lea ecx, [rax-65]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90
jle IFEQUALITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
lea ecx, [rax-26]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
IFEQUALITER:
mov rax, qword ptr [rbp-8]
add rax, 1
cmp qword ptr [rbp-48], rax
jne ELSELOOPITER
mov qword ptr [rbp-8], 0
jmp INCREMENTLOOP
ELSELOOPITER:
add qword ptr [rbp-8], 1
INCREMENTLOOP:
add dword ptr [rbp-12], 1
jmp FORLOOP
ENDFUN:
nop
pop rbp
ret
enVigenereAsm endp

deVigenereAsm proc
push rbp
mov rbp, rsp
mov qword ptr [rbp-24], rcx
mov qword ptr [rbp-32], rdx
mov qword ptr [rbp-40], r8
mov qword ptr [rbp-48], r9
mov qword ptr [rbp-8], 0
mov dword ptr [rbp-12], 0
FORLOOP:
mov eax, dword ptr [rbp-12]
cmp qword ptr [rbp-40], rax
jle ENDFUN
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 64
jle IFEQUALITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90
jg IFEQUALITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx edx, byte ptr [rax]
mov rcx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rcx
movzx eax, byte ptr [rax]
cmp dl, al
jl ELSELOOP
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
mov edx, eax
mov eax, ecx
sub eax, edx
lea ecx, [rax+65]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
jmp IFEQUALITER
ELSELOOP:
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
mov edx, eax
mov eax, ecx
sub eax, edx
lea ecx, [rax+91]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
IFEQUALITER:
mov rax, qword ptr [rbp-8]
add rax, 1
cmp qword ptr [rbp-48], rax
jne ELSELOOPITER
mov qword ptr [rbp-8], 0
jmp INCREMENTLOOP
ELSELOOPITER:
add qword ptr [rbp-8], 1
INCREMENTLOOP:
add dword ptr [rbp-12], 1
jmp FORLOOP
ENDFUN:
nop
pop rbp
ret
deVigenereAsm endp

END