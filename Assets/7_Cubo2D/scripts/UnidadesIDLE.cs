using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadesIDLE {

	public double v_base = 0f;
	public int v_exponente = 0;


	public UnidadesIDLE(): this (0f,0){ }

	public UnidadesIDLE(double v_base, int v_exponente){
		this.v_base = v_base;
		this.v_exponente = v_exponente;
	
	}

	public void setUnidad( UnidadesIDLE _unidad){
		v_base = _unidad.v_base;
		v_exponente = _unidad.v_exponente;

		//this = unidadesIDLE.calcularNotacion (this);
	}

	public static UnidadesIDLE calcularNotacion(UnidadesIDLE _unidad){
		/**Este calculo no va aqui*/
		if (_unidad.v_base > 99999) {
			_unidad.v_base = _unidad.v_base / 1000;
			_unidad.v_exponente += 1;

		} else if (_unidad.v_base < 100 && _unidad.v_exponente > 0) {
			_unidad.v_base = _unidad.v_base * 1000;
			_unidad.v_exponente += -1;
		} else {
			return _unidad;
		}


		return calcularNotacion( _unidad);
	}

	/**Primero es mayor #return > 0, igual #return = 0, Primero es menor #return < 0*/
	public static int comparar(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		if (_unidad1.v_exponente > _unidad2.v_exponente) {
			return 1;
		} else if (_unidad1.v_exponente < _unidad2.v_exponente) {
			return -1;
		} else {
			if (_unidad1.v_base > _unidad2.v_base) {
				return 1;
			} else if (_unidad1.v_base < _unidad2.v_base) {
				return -1;
			} else {
				return 0;
			}
		}
	}

	/**puede fallar con numeros mayores a E+30s*/
	public float toFloat(){

		if (v_exponente > 30) {
			return float.MaxValue;
		}

		float valorReal = (float)(v_base * (float)Mathf.Pow (1000, v_exponente));

		return valorReal;
	}
    public override bool Equals(object obj)
    {
		var otraUnidad = (UnidadesIDLE)obj;
		if (otraUnidad != null) {
			return this.v_base == otraUnidad.v_base && this.v_exponente == otraUnidad.v_exponente;
		}
        return false;
    }

    public static UnidadesIDLE operator +(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		UnidadesIDLE resultado = new UnidadesIDLE(), unidadMayor = _unidad1, unidadMenor = _unidad2;


		if(_unidad1 > _unidad2){
			unidadMayor = _unidad1; unidadMenor = _unidad2;
		}else if(_unidad1 < _unidad2){
			unidadMayor = _unidad2; unidadMenor = _unidad1;
		}/*else{
			resultado.v_base = unidadMayor.v_base + unidadMenor.v_base;
			resultado.v_exponente = unidadMenor.v_exponente;
		}*/

		int diferenciaDeExponent = unidadMayor.v_exponente - unidadMenor.v_exponente;

		if (diferenciaDeExponent > 4) {
			//Debug.Log (" despreciable  ");
			resultado.setUnidad (unidadMayor);
		}else {		
			resultado.v_base = unidadMayor.v_base * Mathf.Pow (1000, diferenciaDeExponent) + unidadMenor.v_base;
			//Debug.Log (" > -----------------");
			resultado.v_exponente = unidadMenor.v_exponente;
		}


		return calcularNotacion(resultado);
	}


	/** este metodo no resulta numeros negativos */
	public static UnidadesIDLE operator -(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		UnidadesIDLE resultado = new UnidadesIDLE();

		if (_unidad1 < _unidad2)
			return new UnidadesIDLE (0f, 0);


		if (_unidad1 > _unidad2) {
			if (_unidad1.v_exponente - _unidad2.v_exponente > 4) {
				resultado.setUnidad (_unidad1);
			} else {		
				resultado.v_base = _unidad1.v_base * Mathf.Pow (1000, _unidad1.v_exponente - _unidad2.v_exponente) - _unidad2.v_base;
				resultado.v_exponente = _unidad2.v_exponente;
			}

		}

		return calcularNotacion(resultado);
	}

	public static UnidadesIDLE operator *(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		
		UnidadesIDLE resultado = new UnidadesIDLE();

		resultado.v_base = _unidad1.v_base * _unidad2.v_base;
		resultado.v_exponente = _unidad1.v_exponente + _unidad2.v_exponente;

		return calcularNotacion(resultado);

		return _unidad1;
	}

	public static UnidadesIDLE operator /(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){

		if (_unidad1.v_exponente - _unidad2.v_exponente < 0) {
			float proporcion  = (float)((_unidad1.v_base * Mathf.Pow (1000, _unidad1.v_exponente - _unidad2.v_exponente)) / _unidad2.v_base);

			return new UnidadesIDLE (proporcion, 0);
		}
			

		UnidadesIDLE resultado = new UnidadesIDLE();




		resultado.v_base = _unidad1.v_base / _unidad2.v_base;
		resultado.v_exponente = _unidad1.v_exponente - _unidad2.v_exponente;

		return calcularNotacion(resultado);

		//return new unidadesIDLE (_unidad1.v_base / _unidad2.v_base, _unidad1.v_exponente - _unidad2.v_exponente);
	}

	public static bool operator >(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		if (_unidad1.v_exponente > _unidad2.v_exponente) {
			return true;
		} else if ( _unidad1.v_exponente == _unidad2.v_exponente && _unidad1.v_base > _unidad2.v_base) {
			return true;
		}
		return false;
	}

	public  bool esMayorACero(){
		return v_base > 0f;
	}

	public static bool esNull(UnidadesIDLE _unidad1){
		return _unidad1 == null;
	}

	public static bool operator <(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		if (_unidad1.v_exponente < _unidad2.v_exponente) {
			return true;
		} else if ( _unidad1.v_exponente == _unidad2.v_exponente && _unidad1.v_base < _unidad2.v_base) {
			return true;
		}
		return false;
	}

	public static bool operator ==(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		if(_unidad1.v_exponente == _unidad2.v_exponente && _unidad1.v_base == _unidad2.v_base )
			return true;

		return false;
	}


	public static bool operator !=(UnidadesIDLE _unidad1,UnidadesIDLE _unidad2){
		if( ! (_unidad1 == _unidad2) )
			return true;

		return false;
	}
	

	public override int GetHashCode ()
	{
		unchecked {
			return v_base.GetHashCode () ^ v_exponente.GetHashCode ();
		}
	}
	
		

	public static string toStringText(UnidadesIDLE _unidad){
		return _unidad.v_base + "-" + _unidad.v_exponente;
	}

	public static UnidadesIDLE fromStringText(string _text){
		
		UnidadesIDLE _unidad = new UnidadesIDLE();
		string[] split = _text.Split ('-');
		_unidad.v_base = double.Parse( split [0]);
		_unidad.v_exponente = int.Parse(split [1]);
	//	Debug.Log ("base " + _unidad.v_base + " exp " +_unidad.v_exponente);
		return _unidad;
	}

	public override string ToString ()
	{
		return string.Format ("[unidadesIDLE: v_base={0}, v_exponente={1}]", v_base, v_exponente);
	}
	
}
