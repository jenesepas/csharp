--
-- PostgreSQL database dump
--

-- Dumped from database version 9.3.5
-- Dumped by pg_dump version 9.3.5
-- Started on 2015-03-18 11:18:32

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 170 (class 1259 OID 32769)
-- Name: clientes; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE clientes (
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


ALTER TABLE public.clientes OWNER TO postgres;

--
-- TOC entry 1937 (class 0 OID 32769)
-- Dependencies: 170
-- Data for Name: clientes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY clientes (id_cliente, nombre, tipo_docu, documento, letra, direccion, pers_cont, email, telf1, telf2, cpostal, ciudad, provin, tipo_cte) FROM stdin;
0	                                                            	DNI 	                                                            	 	                                                            	                                                            	                                                            	                    	                    	          	                                                  	                                                            	C
3	Talleres Pacoche                                            	CIF 	8876512                                                     	Q	Polígono Urbaalmansa, nº 56                                 	Paco Mer                                                    	paco.mer@pacoche.com                                        	966123123           	606606606           	02400     	Almansa                                           	Albacete                                                    	C
4	Maria Lopez Juan                                            	DNI 	23456789                                                    	S	Salsipuedes nº 37, 2º dcha.                                 	Maria                                                       	marialopez@yahoo.es                                         	661661661           	                    	30520     	Jumilla                                           	Murcia                                                      	T
1	Dionisio Gómez Pérez                                        	DNI 	22222222                                                    	A	Las Eras, 56                                                	Pepito Perez                                                	pepeito@perez.com                                           	967340000           	667667667           	02460     	Caudete                                           	Albacete                                                    	T
2	Mercedes Soriano Salar                                      	CIF 	234567889                                                   	E	San Sebastián nº 86, 1ºD                                    	Pepito                                                      	ddddddd@ssss.es                                             	968717171           	699699699           	03400     	Villena                                           	Alicante                                                    	C
5	Abdon Lucas Moura                                           	DNI 	23456789                                                    	S	Las Huertas, 122, 10 D                                      	                                                            	                                                            	666111222           	                    	30002     	Murcia                                            	Murcia                                                      	T
8	New customer                                                	NIE 	7676767676                                                  	V	                                                            	                                                            	                                                            	                    	                    	          	                                                  	                                                            	T
7	Fausto Hernandez Fernandes                                  	NIF 	123667788                                                   	F	                                                            	                                                            	                                                            	                    	                    	02400     	Almansa                                           	Albacete                                                    	T
6	Talleres Espinosa                                           	CIF 	234567689                                                   	Q	                                                            	                                                            	                                                            	                    	                    	03400     	Villena                                           	Alicante                                                    	C
\.


--
-- TOC entry 1829 (class 2606 OID 32774)
-- Name: cte_id_pk; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY clientes
    ADD CONSTRAINT cte_id_pk PRIMARY KEY (id_cliente);


-- Completed on 2015-03-18 11:18:33

--
-- PostgreSQL database dump complete
--

