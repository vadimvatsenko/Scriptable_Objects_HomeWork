using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuthLoginSample
{
    public class ProfileController
    {
        private readonly FireBaseService fireBaseService; 

        private readonly ProfilePageView profilePageView; 

        private readonly PageRoutingController pageRoutingController; 

        private readonly UserModel userModel;

        public ProfileController(FireBaseService fireBaseService, ProfilePageView profilePageView, PageRoutingController pageRoutingController, UserModel userModel)
        {
            this.fireBaseService = fireBaseService;
            this.profilePageView = profilePageView;
            this.pageRoutingController = pageRoutingController;
            this.userModel = userModel;            
        }

        public void Initialize()
        {
            fireBaseService.OnStateChanged += ChancheUserInfo;
            userModel.UserInfo.OnValueChanged += OnUserInfoChange;
            profilePageView.OnQuitClick += QuitFromProfile;
        }

        ~ProfileController()
        {
            fireBaseService.OnStateChanged -= ChancheUserInfo;
        }

        private void OnUserInfoChange(FirebaseUser user1, FirebaseUser user2)
        {
            profilePageView.ID = user2.UserId;
            profilePageView.Name = user2.DisplayName;
            profilePageView.Email = user2.Email;
            profilePageView.Password = " ";

        }

        private void ChancheUserInfo(FirebaseUser user)
        {
            userModel.UserInfo.Value = user;   
        }

        private void QuitFromProfile()
        {
            profilePageView.ID = " ";
            profilePageView.Name = " ";
            profilePageView.Email = " ";
            profilePageView.Password = " ";

            fireBaseService.QuitFromProfile();

            pageRoutingController.ChangePage(CurrentPage.Login);
        }
        
    }
}

