echo conectando unidad z .....
net use z: \\172.26.0.223\datos_asegest /YES

echo copiando ficheros ...

z:
cd z:\asegest
copy *.* c:\asegest

echo ficheros copiados.