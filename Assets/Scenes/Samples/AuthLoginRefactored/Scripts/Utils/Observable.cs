namespace AuthLoginSample
{
    using System;

    public class Observable<T> // �������� ����� ������� ����� ��������� ������������ �������� // � ������ ������ ����� ��������� ��������
    {
        private T _value; // �������� ��������
        
        public event Action<T, T> OnValueChanged; // ������������ �������, ��������� ��� ������������ ��������

        public Observable(T initialValue) // �����������, ��������� ������������ ��������
        {
            _value = initialValue; 
        }

        public Observable() // ������ �����������
        {
        }

        public T Value // ��������, ������ ��������
        {
            get => _value;
            set
            {
                if (!Equals(_value, value)) // ���� ���������� �������� � ������� �� �����
                {
                    T oldValue = _value; // ���������� ������ �������� ��������
                    _value = value; // �������������� ��������
                    
                    OnValueChanged?.Invoke(oldValue, _value); // ������� ������� ����� ����������.
                    // ������ ���� �������� ��� ��������, ��������� ���������� � PageRoutingController, ����� �������
                }
            }
        }
    }
}
