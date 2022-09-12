<template >
    <div>
          <!-- Form nhập -->
        <div class="modal">
            <div class="modal__container">
                <div class="modal__content">
                    <div class="modal__header">
                        <div class="modal__header__left">
                            <h1 class="header__title">Thông tin nhân viên </h1>
                            <input class="" type="checkbox" id="" />
                            <label for="">Là khách hàng</label>
                            <input class="" type="checkbox" id="" />
                            <label for="">Là nhà cung cấp</label>
                        </div>
                        <div class="modal__header__rigth">
                            <div class="item__icon modal__header__icon ">
                                <div class=" icon__18 icon__help"></div>
                            </div>
                            <div class="item__icon modal__header__icon  margin__letf_8">
                                <div class=" icon__18 icon__close"></div>
                            </div>
                        </div>


                    </div>
                    <div class="modal__body">
                        <div class="modal__body__row">
                            <div class="body__row__left">
                                <div class="container__input input__160">
                                    <label class="input__label" for="">Mã <span class="required">*</span> </label>
                                    <input tabindex="1" class="input" type="text" placeholder="Mã nhân viên" />
                                </div>
                                <div class="container__input input__margin_6 input__320">
                                    <label class="input__label" for="">Họ và tên <span class="required">*</span></label>
                                    <input tabindex="2" class="input" type="text" placeholder="Họ tên đấy đủ" />
                                </div>
                            </div>
                            <div class="body__row__rigth">
                                <div class="container__input input__160 ">
                                    <label class="input__label" for=""> Ngày sinh </label>
                                    <input tabindex="3" class="input" type="date" />
                                </div>
                                <div class="container__input input__margin_16 input__320">
                                    <label class="input__label " for=""> Giới tính </label>
                                    <div class="container__gender">
                                        <input type="radio" name="" id="" />
                                        <label for="">Nam</label>
                                        <input type="radio" name="" id="" />
                                        <label for="">Nữ</label>
                                        <input type="radio" name="" id="" />
                                        <label for="">Khác</label>
                                    </div>

                                </div>


                            </div>
                        </div>
                        <div class="modal__body__row">
                            <div class="body__row__left">
                                <div class="container__input  input__480">
                                    <label class="input__label" for="">Đơn vị <span class="required">*</span></label>
                                    <input tabindex="7" class="input" type="text" />
                                </div>
                            </div>
                            <div class="body__row__rigth">
                                <div class="container__input  input__320">
                                    <label class="input__label" for="">Số CMND</label>
                                    <input tabindex="9" class="input" type="text"
                                        placeholder="Số chứng minh nhân dân" />
                                </div>
                                <div class="container__input input__margin_6 input__160">
                                    <label class="input__label" for="">Ngày cấp</label>
                                    <input tabindex="10" class="input" type="date" />
                                </div>
                            </div>

                        </div>
                        <div class="modal__body__row">
                            <div class="body__row__left">
                                <div class="container__input  input__480">
                                    <label class="input__label" for="">Chức danh</label>
                                    <input tabindex="8" class="input" type="text" placeholder="Chức danh" />
                                </div>
                            </div>
                            <div class="body__row__rigth">

                                <div class="container__input  input__480">
                                    <label class="input__label" for="">Nơi cấp</label>
                                    <input tabindex="11" class="input" type="text" placeholder="Nơi cấp" />
                                </div>
                            </div>

                        </div>
                        <div class="modal__body__row margin__top_16">

                            <div class="container__input ">
                                <label class="input__label" for="">Địa chỉ</label>
                                <input tabindex="12" class="input" type="text" placeholder="Địa chỉ" />
                            </div>
                        </div>
                        <div class="modal__body__row">
                            <div class="container__input input__240">
                                <label class="input__label" for="">ĐT di động </label>
                                <input tabindex="13" class="input" type="text" placeholder="Điện thoại di động" />
                            </div>
                            <div class="container__input input__margin_6 input__240">
                                <label class="input__label" for="">ĐT có định </label>
                                <input tabindex="14" class="input" type="text" placeholder="Điện thoại cố định" />
                            </div>
                            <div class="container__input input__margin_6 input__240">
                                <label class="input__label" for="">Email </label>
                                <input tabindex="15" class="input" type="text" placeholder="Email" />
                            </div>

                        </div>
                        <div class="modal__body__row">
                            <div class="container__input input__240">
                                <label class="input__label" for="">Tài khoản ngân hàng </label>
                                <input tabindex="16" class="input" type="text" placeholder="Tài khoản ngân hàng" />
                            </div>
                            <div class="container__input input__margin_6 input__240">
                                <label class="input__label" for="">Tên ngân hàng </label>
                                <input tabindex="17" class="input" type="text" placeholder="Tên ngân hàng" />
                            </div>
                            <div class="container__input input__margin_6 input__240">
                                <label class="input__label" for=""> Chi nhánh </label>
                                <input tabindex="18" class="input" type="text" placeholder="Chi nhánh" />
                            </div>

                        </div>
                    </div>
                    <div class="modal__footer">
                        <div class="btn__base content__center ">Hủy</div>
                        <div class="modal__footer__rigth">
                            <div class="btn__base content__center ">Cất</div>
                            <div class="btn margin__letf_8">Cất và thêm</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
   name : 'EmployeeDetailComponent',
   
}
</script>