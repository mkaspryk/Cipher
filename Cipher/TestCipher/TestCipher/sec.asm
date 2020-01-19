

;Vigenere Cipher
encryptVigenereAsm proc
push rbp
mov rbp, rsp
mov qword ptr [rbp-24], rcx                ; Copies rcx(sentence) register to ptr [rbp-24] (memory address) register
mov qword ptr [rbp-32], rdx                ; Copies rdx(keyword) register to ptr [rbp-32] (memory address)
mov qword ptr [rbp-40], r8                 ; Copies r8(size sentene) register to ptr [rbp-40] (memory address)
mov qword ptr [rbp-48], r9                 ; Copies r9(size keyword) register to ptr [rbp-48] (memory address)
;FOR LOOP
mov qword ptr [rbp-8], 0
mov dword ptr [rbp-12], 0
FOR_LOOP:
mov eax, dword ptr [rbp-12]
cmp qword ptr [rbp-40], rax                ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr[rbp-40]
jle END_FUN                                ; If rax is greater or equal to ptr[rbp-40] jump to label END_FUN
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 64                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 ('A'-1)
jle IF_EQUAL_ITER                          ; If al is less or equal to 64 jump to IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jg IF_EQUAL_ITER                           ; If al is greater than 90 jump to label IF_EQUAL_ITER
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
cmp al, 90                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jle IF_EQUAL_ITER                          ; If al is less or equal to 64 jump to IF_EQUAL_ITER
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
IF_EQUAL_ITER:
mov rax, qword ptr [rbp-8]
add rax, 1
cmp qword ptr [rbp-48], rax                ; Sets flags corresponding to whether ptr [rbp-48] value is less than, equal to, or greater than rax
jne ELSE_LOOP_ITER                         ; If ptr [rbp-48] value is not equal to rax jump to ELSE_LOOP_ITER
mov qword ptr [rbp-8], 0
jmp INCREMENT_LOOP
ELSE_LOOP_ITER:
add qword ptr [rbp-8], 1
INCREMENT_LOOP:
add dword ptr [rbp-12], 1
jmp FOR_LOOP
END_FUN:
nop
pop rbp
ret
encryptVigenereAsm endp
end



