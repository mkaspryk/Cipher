.code

testAVX proc
push rbp                        
mov rbp, rsp
mov rax,rcx                           ; zdanie 
mov qword ptr[rbp-8],rdx              ; przesuniêcie
vpbroadcastb xmm2,byte ptr[rbp-8]
vpaddb xmm0, xmm2,byte ptr[rax]
movq qword ptr[rax],xmm0
nop
pop rbp
ret
testAVX endp

caesar proc
push rbp
mov rbp,rsp
mov qword ptr[rbp-8],rcx 
mov qword ptr[rbp-16],rdx
mov qword ptr[rbp-24],r8
mov qword ptr[rbp-32],0   ; wsk 
mov r15,65
movq xmm0,r15
vpbroadcastb xmm1,xmm0
WHILE_LOOP:
mov rbx, qword ptr[rbp-32]
cmp rbx, qword ptr[rbp-24]
jge END_FUN
mov rax, qword ptr[rbp-32]
mov rbx, qword ptr[rbp-8]
add rbx,rax
mov r15,rbx
movq xmm2, qword ptr[r15]
mov rbx, qword ptr[rbp-16]
add rbx,rax
mov r14,rbx
movq xmm3, qword ptr[r14]
vpsubb xmm4,xmm3, xmm1
vpaddb xmm5,xmm2,xmm4
movq qword ptr[r15],xmm5
mov rax, qword ptr [rbp-32]
mov qword ptr [rbp-40], rax
FOR_LOOP:
mov rax, qword ptr [rbp-32]
add rax, 7
cmp qword ptr [rbp-40], rax
jg TO_WHILE
mov rbx, qword ptr [rbp-40]
mov rax, qword ptr [rbp-8]
add rax, rbx
movzx eax, byte ptr [rax]
cmp al, 90
jle INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-40]
mov rax, qword ptr [rbp-8]
add rax, rbx
movzx eax, byte ptr [rax]
lea edi, [rax-26]
mov rbx, qword ptr [rbp-40]
mov rax, qword ptr [rbp-8]
add rax, rbx
mov ebx, edi
mov byte ptr [rax], bl
INCREMENT_FOR_LOOP:
add qword ptr [rbp-40], 1
jmp FOR_LOOP
TO_WHILE:
add qword ptr[rbp-32],8
jmp WHILE_LOOP
END_FUN:
nop
pop rbp
ret
caesar endp
end