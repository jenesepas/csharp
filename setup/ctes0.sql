PGDMP                         s         	   asesoria0    9.3.5    9.3.5     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            �            1259    16394    clientes    TABLE     �  CREATE TABLE clientes (
    id_cliente integer NOT NULL,
    nombre character(60),
    tipo_docu character(4),
    documento character(60),
    letra character(1),
    direccion character(60),
    pers_cont character(60),
    email character(60),
    telf1 character(20),
    telf2 character(20),
    cpostal character(10),
    ciudad character(50),
    provin character(60),
    tipo_cte character(1) DEFAULT 'C'::bpchar NOT NULL
);
    DROP TABLE public.clientes;
       public         postgres    false            �          0    16394    clientes 
   TABLE DATA               �   COPY clientes (id_cliente, nombre, tipo_docu, documento, letra, direccion, pers_cont, email, telf1, telf2, cpostal, ciudad, provin, tipo_cte) FROM stdin;
    public       postgres    false    170          !           2606    16399 	   cte_id_pk 
   CONSTRAINT     Q   ALTER TABLE ONLY clientes
    ADD CONSTRAINT cte_id_pk PRIMARY KEY (id_cliente);
 <   ALTER TABLE ONLY public.clientes DROP CONSTRAINT cte_id_pk;
       public         postgres    false    170    170            �   �  x��T�n�@>/O�`?���6�hcc�S/#n*���C�6}���G}�����.��@&���~�����qF�e��W�[A����L,�$"�ŞS�$��`�bF-��j:���ӆ�x��%]�j�K^rD�e��S��#�C�d,P�:ސ�S$�f��gk���z�_��]	6�'�= ��pĂ0�L2L�
�����髠��@C6���0�+Åc##[eq�f�Z�0pۧdQ��tڻ�>_3!x:u�"K�0�8�|�X���V��t��Hq��F���'�����.I_��ȡ�ap��U��m��Q��vΫ�T��()f��w��aʻA��ⱚO��^2N�!YB�]�ݼAI�$P{Z��DŔ�QƢ�ʆo񚵼���z�ަ;�o'P���[�hg�?`'���q)�ʻ�?O��ȻP<orԱ�˦JMG�M�f[��b��     