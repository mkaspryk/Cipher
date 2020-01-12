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
caesar endp

end