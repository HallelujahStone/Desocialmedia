
using System;
using UniRx;
using UnityEngine;

namespace Desocialmedia
{
    public class TabManager : SingletonMonoBehaviour<TabManager>
    {
        private readonly Subject<int> _onTabClick = new Subject<int>();
        public IObservable<int> OnTabClick() => _onTabClick;
        
        [SerializeField] private TabController[] tabControllers;

        private int _activeTabIndex;
        
        private void Start()
        {
            for (int i = 0; i < tabControllers.Length; i++)
            {
                int i1 = i;
                tabControllers[i].OnButtonUp()
                    .Subscribe(_ => SwitchTab(i1))
                    .AddTo(gameObject);
            }
            
            tabControllers[_activeTabIndex].SetActiveTab();
        }

        private void SwitchTab(int index)
        {
            if (_activeTabIndex == index) return;
            
            tabControllers[_activeTabIndex].SetInactiveTab();
            _activeTabIndex = index;

            _onTabClick.OnNext(_activeTabIndex);
        }
    }
}