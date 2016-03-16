--
-- PostgreSQL database dump
--

-- Dumped from database version 9.3.5
-- Dumped by pg_dump version 9.3.5
-- Started on 2015-03-18 11:26:08

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
-- TOC entry 171 (class 1259 OID 16400)
-- Name: registros; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE registros (
    delegacion character(1) NOT NULL,
    n_reg integer NOT NULL,
    fec_ent date,
    id_cte integer DEFAULT 0 NOT NULL,
    id_titular integer DEFAULT 0 NOT NULL,
    seccion_int character(10),
    seccion character(30),
    t_tramite character(30),
    matricula character(10),
    estado character(20),
    factura integer DEFAULT 0 NOT NULL,
    fec_fra date,
    observacion character(100),
    base_imp numeric(10,2) DEFAULT 0 NOT NULL,
    p_iva smallint DEFAULT 0 NOT NULL,
    tasa numeric(10,2) DEFAULT 0 NOT NULL,
    exp_tl character(20),
    fec_pre_exp date,
    tasa_tl integer DEFAULT 0 NOT NULL,
    tipo_tl character(20),
    cambio_serv character(20),
    bate_ant character(10),
    nif character(12),
    dcho_col numeric(10,2) DEFAULT 0 NOT NULL,
    t_cte_fra character(1)
);


ALTER TABLE public.registros OWNER TO postgres;

--
-- TOC entry 1944 (class 0 OID 16400)
-- Dependencies: 171
-- Data for Name: registros; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY registros (delegacion, n_reg, fec_ent, id_cte, id_titular, seccion_int, seccion, t_tramite, matricula, estado, factura, fec_fra, observacion, base_imp, p_iva, tasa, exp_tl, fec_pre_exp, tasa_tl, tipo_tl, cambio_serv, bate_ant, nif, dcho_col, t_cte_fra) FROM stdin;
Y	0	2014-12-29	0	0	          	                              	                              	          	                    	0	2014-12-29	                                                                                                    	0.00	0	0.00	                    	2014-12-29	0	                    	                    	          	            	0.00	 
Y	2	2015-01-08	2	1	GESTASER  	Conductores                   	Renovación Permiso            	A-1234-CB 	PTE. CLIENTE        	0	2015-01-08	                                                                                                    	0.00	0	0.00	                    	2015-01-08	0	                    	                    	          	            	0.00	C
Y	3	2015-01-08	3	4	AUPO      	Seg. Social                   	Bajas Empleado/a Hogar        	          	PTE. GESTORÍA       	0	2015-01-08	                                                                                                    	0.00	0	0.00	                    	2015-01-08	0	                    	                    	          	            	0.00	C
Y	4	2015-01-08	2	0	GESTASER  	Hacienda                      	Requerimientos Hacienda       	          	PTE. CLIENTE        	0	2015-01-08	                                                                                                    	0.00	0	0.00	                    	2015-01-08	0	                    	                    	          	            	0.00	C
Y	1	2014-12-28	0	1	GESTASER  	Hacienda                      	Requerimientos Hacienda       	MU-2266-BB	PTE. CLIENTE        	1	2014-12-28	                                                                                                    	12.34	21	8.90	140001              	2014-12-28	12345678	1.5                 	                    	          	            	0.00	T
\.


--
-- TOC entry 1834 (class 2606 OID 16412)
-- Name: reg_id_pk; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY registros
    ADD CONSTRAINT reg_id_pk PRIMARY KEY (delegacion, n_reg);


--
-- TOC entry 1831 (class 1259 OID 16425)
-- Name: fki_reg_cte_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_reg_cte_fk ON registros USING btree (id_cte);


--
-- TOC entry 1832 (class 1259 OID 16426)
-- Name: fki_reg_tit_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fki_reg_tit_fk ON registros USING btree (id_titular);


--
-- TOC entry 1835 (class 2606 OID 16415)
-- Name: reg_cte_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY registros
    ADD CONSTRAINT reg_cte_fk FOREIGN KEY (id_cte) REFERENCES clientes(id_cliente);


--
-- TOC entry 1836 (class 2606 OID 16420)
-- Name: reg_tit_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY registros
    ADD CONSTRAINT reg_tit_fk FOREIGN KEY (id_titular) REFERENCES clientes(id_cliente);


-- Completed on 2015-03-18 11:26:10

--
-- PostgreSQL database dump complete
--

