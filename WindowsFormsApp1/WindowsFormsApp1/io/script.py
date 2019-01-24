import pandas as pd


def lector():
	#Abro csv
	#Leo por columnas el CSV y las guardo en un txt
	print(". . . LECTOR . . .")
	csv_file = "../in/info_canios.csv"
	df = pd.read_csv(csv_file, delimiter=";")
	saved_column = df #you can also use df['column_name']
	#print(df["diam_mm"])
	
	fout = open("datos_formateados.txt","w")
	a=len(df['espesor'])
	print("a: ",a)
	fout.write(str(a)+"\n")
	#fout.write("diam\n")
	print(len(df['diam_mm']))
	for e in list(df['diam_mm']):
		fout.write(str(e)+"\n")
		#print("Guardando ",e)
	#fout.write("peso\n")
	print(len(df['peso']))
	for e in list(df['peso']):
		fout.write(str(e)+"\n")
		#print("Guardando ", e)
	#fout.write("altura\n")
	print(len(df['altura_paquete']))
	for e in list(df["altura_paquete"]):
		fout.write(str(e) + "\n")
		#print("Guardando ", e)		
	#fout.write("metros_paquete\n")
	for e in list(df["metros_paquete"]):
		fout.write(str(e) + "\n")
		#print("Guardando ",e)
	#fout.write("espesor\n")
	for e in list(df["espesor"]):
		fout.write(str(e) +"\n")
		#print("Guardando ", e)
	#fout.write("cant_canios\n")
	#fout.write(str(len(df['espesor'])))
	print(len(df['espesor']))
	for e in list(df['cant_canios_paquete']):
		fout.write(str(e)+"\n")
def main():
	print("Inicio formato")
	lector()
	print("Fin formateado")
	
main()
